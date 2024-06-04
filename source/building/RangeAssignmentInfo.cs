using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

using Arinc424.Diagnostics;

namespace Arinc424.Building;

[DebuggerDisplay($"{{{nameof(Property)}}} - {{{nameof(range)}}}")]
internal abstract class RangeAssignmentInfo<TRecord>(PropertyInfo property, Regex? regex, Range range)
    : AssignmentInfo(property, regex) where TRecord : Record424
{
    protected readonly Range range = range;

    [Obsolete("todo")]
    protected static Action<TRecord, TValue> CompileSetter<TValue>(PropertyInfo property)
    {
        var record = Expression.Parameter(typeof(TRecord));

        var value = Expression.Parameter(typeof(TValue), property.Name);

        var setter = Expression.Property(record, property.Name);

        Expression rightExpression = value;

        // todo: reduce check
        if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            rightExpression = Expression.New(property.PropertyType.GetConstructor([typeof(TValue)])!, value);

        return Expression.Lambda<Action<TRecord, TValue?>>
        (
            Expression.Assign(setter, rightExpression), record, value
        ).Compile();
    }

    internal abstract void Process(TRecord record, ReadOnlySpan<char> @string, Queue<Diagnostic> diagnostics);
}

internal sealed class DecodeAssignmentInfo<TRecord, TValue>(PropertyInfo property, Regex? regex, Range range, DecodeAttribute<TValue> decode)
    : RangeAssignmentInfo<TRecord>(property, regex, range)
        where TValue : notnull
        where TRecord : Record424
{
    private readonly Action<TRecord, TValue> set = CompileSetter<TValue>(property);

    private readonly DecodeAttribute<TValue> decode = decode;

    internal override void Process(TRecord record, ReadOnlySpan<char> @string, Queue<Diagnostic> diagnostics)
    {
        var @field = @string[range];

        if (@field.IsWhiteSpace())
        {
            // todo: process nullability by provided conditional settings

            /*if (NullabilityInfo.WriteState is NullabilityState.NotNull)
            {
                diagnostic = new NullDiagnostic(record, $"Property {Property} does not allow blank values.", range);
                return false;
            }*/
            return;
        }

        var result = decode.Convert(@field);

        if (result.IsError)
        {
            diagnostics.Enqueue(new ValueDiagnostic(record, result.Problem!, range));
            return;
        }
        set(record, result.Value);
    }
}

internal class StringAssignmentInfo<TRecord>(PropertyInfo property, Regex? regex, Range range)
    : RangeAssignmentInfo<TRecord>(property, regex, range) where TRecord : Record424
{
    private readonly Action<TRecord, string> set = CompileSetter<string>(property);

    internal override void Process(TRecord record, ReadOnlySpan<char> @string, Queue<Diagnostic> diagnostics)
    {
        var @field = @string[range];

        if (@field.IsWhiteSpace())
        {
            // todo: process nullability by provided conditional settings

            /*if (NullabilityInfo.WriteState is NullabilityState.NotNull)
            {
                diagnostic = new NullDiagnostic(record, $"Property {Property} does not allow blank values.", range);
                return false;
            }*/
            return;
        }
        set(record, @field.Trim().ToString());
    }
}
