using System.Collections.Immutable;
using System.Reflection;

namespace Arinc424.Building;

[DebuggerDisplay($"{{{nameof(property)}}} - {{{nameof(range)}}}")]
internal abstract class RangeAssignment<R>(PropertyInfo property, Range range)
    : Assignment<R>(property)
        where R : Record424
{
    protected readonly Range range = range;
}

internal sealed class DecodeAssignment<R, T>(PropertyInfo property, Range range, DecodeAttribute<T> decode)
    : RangeAssignment<R>(property, range)
        where T : notnull
        where R : Record424
{
    private readonly DecodeAttribute<T> decode = decode;

    private readonly Action<R, T> set = GetCompiledSetter<T>(property);

    internal override void Assign(R record, ReadOnlySpan<char> @string, Queue<Diagnostic> diagnostics)
    {
        var @field = @string[range];

        if (@field.IsWhiteSpace())
        {
            if (nullState == NullabilityState.NotNull)
            {
                diagnostics.Enqueue(new Null()
                {
                    Range = range,
                    Record = record,
                    Property = property
                });
            }
            return;
        }
        var result = decode.Convert(@field);

        if (!result.Invalid)
        {
            set(record, result.Value);
            return;
        }
        diagnostics.Enqueue(new BadValue
        {
            Range = range,
            Record = record,
            Property = property,
            Value = result.Bad.ToImmutableArray()
        });
    }
}

internal sealed class StringAssignment<R>(PropertyInfo property, Range range)
    : RangeAssignment<R>(property, range)
        where R : Record424
{
    private readonly Action<R, string> set = GetCompiledSetter<string>(property);

    internal override void Assign(R record, ReadOnlySpan<char> @string, Queue<Diagnostic> diagnostics)
    {
        var @field = @string[range].Trim();

        if (@field.IsEmpty)
        {
            if (nullState == NullabilityState.NotNull)
            {
                diagnostics.Enqueue(new Null()
                {
                    Range = range,
                    Record = record,
                    Property = property
                });
            }
            return;
        }
        set(record, @field.ToString());
    }
}
