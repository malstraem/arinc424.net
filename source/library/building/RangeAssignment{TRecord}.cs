using System.Collections.Immutable;
using System.Reflection;

namespace Arinc424.Building;

using Diagnostics;

[DebuggerDisplay($"{{{nameof(property)}}} - {{{nameof(range)}}}")]
internal abstract class RangeAssignment<TRecord>(PropertyInfo property, Range range)
    : Assignment<TRecord>(property)
        where TRecord : Record424
{
    protected readonly Range range = range;
}

internal sealed class DecodeAssignment<TRecord, TType>(PropertyInfo property, Range range, DecodeAttribute<TType> decode)
    : RangeAssignment<TRecord>(property, range)
        where TType : notnull
        where TRecord : Record424
{
    private readonly DecodeAttribute<TType> decode = decode;

    private readonly Action<TRecord, TType> set = GetCompiledSetter<TType>(property);

    internal override void Assign(TRecord record, ReadOnlySpan<char> @string, Queue<Diagnostic> diagnostics)
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

internal sealed class StringAssignment<TRecord>(PropertyInfo property, Range range)
    : RangeAssignment<TRecord>(property, range)
        where TRecord : Record424
{
    private readonly Action<TRecord, string> set = GetCompiledSetter<string>(property);

    internal override void Assign(TRecord record, ReadOnlySpan<char> @string, Queue<Diagnostic> diagnostics)
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
