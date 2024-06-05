using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

using Arinc424.Diagnostics;

namespace Arinc424.Building;

[DebuggerDisplay($"{{{nameof(Property)}}} - {{{nameof(range)}}}")]
internal abstract class RangeAssignment<TRecord>(PropertyInfo property, Regex? regex, Range range)
    : Assignment<TRecord>(property, regex) where TRecord : Record424
{
    protected readonly Range range = range;

    [Obsolete("todo: maybe replace with emit op codes")]
    protected static Action<TRecord, TType> GetCompiledSetter<TType>(PropertyInfo property, bool isValueNullable)
    {
        var record = Expression.Parameter(typeof(TRecord));

        var value = Expression.Parameter(typeof(TType), property.Name);

        var setter = Expression.Property(record, property.Name);

        Expression rightExpression = value;

        if (isValueNullable)
            rightExpression = Expression.New(property.PropertyType.GetConstructor([typeof(TType)])!, value);

        return Expression.Lambda<Action<TRecord, TType>>(Expression.Assign(setter, rightExpression), record, value).Compile();
    }
}

internal sealed class DecodeAssignment<TRecord, TValue>(PropertyInfo property, Regex? regex, Range range, DecodeAttribute<TValue> decode, bool isValueNullable)
    : RangeAssignment<TRecord>(property, regex, range)
        where TValue : notnull
        where TRecord : Record424
{
    private readonly Action<TRecord, TValue> set = GetCompiledSetter<TValue>(property, isValueNullable);

    private readonly DecodeAttribute<TValue> decode = decode;

    internal override void Assign(TRecord record, ReadOnlySpan<char> @string, Queue<Diagnostic> diagnostics)
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

internal sealed class StringAssignment<TRecord>(PropertyInfo property, Regex? regex, Range range)
    : RangeAssignment<TRecord>(property, regex, range) where TRecord : Record424
{
    private readonly Action<TRecord, string> set = GetCompiledSetter<string>(property, false);

    internal override void Assign(TRecord record, ReadOnlySpan<char> @string, Queue<Diagnostic> diagnostics)
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
