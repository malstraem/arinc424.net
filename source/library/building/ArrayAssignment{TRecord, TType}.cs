using System.Collections.Immutable;
using System.Reflection;

using Arinc424.Diagnostics;

namespace Arinc424.Building;

internal sealed class ArrayAssignment<TRecord, TType>(PropertyInfo property, Range range, DecodeAttribute<TType> decode, uint count)
    : RangeAssignment<TRecord>(property, range) where TRecord : Record424 where TType : notnull
{
    private readonly uint count = count;

    private readonly DecodeAttribute<TType> decode = decode;

    private readonly Action<TRecord, TType[]> set = GetCompiledSetter<TType[]>(property);

    internal override void Assign(TRecord record, ReadOnlySpan<char> @string, Queue<Diagnostic> diagnostics)
    {
        List<TType> values = [];

        var range = this.range;

        int length = range.End.Value - range.Start.Value;

        for (int i = 0; i < count; i++)
        {
            var @field = @string[range];

            if (@field.IsWhiteSpace())
                break;

            var result = decode.Convert(@field);

            if (result.Invalid)
                diagnostics.Enqueue(new InvalidValue(record, property, result.Bad.ToImmutableArray(), range));
            else
                values.Add(result.Value);

            range = new(range.Start.Value + length, range.End.Value + length);
        }
        set(record, [.. values]);
    }
}
