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
        var range = this.range;

        int arrayLength = 0, fieldLength = range.End.Value - range.Start.Value;
        for (int i = 0; i < count; i++)
        {
            if (@string[range].IsWhiteSpace())
                break;
            arrayLength++;
            range = new(range.Start.Value + fieldLength, range.End.Value + fieldLength);
        }
        range = this.range;

        var values = new TType[arrayLength];

        for (int i = 0; i < arrayLength; i++)
        {
            var @field = @string[range];

            var result = decode.Convert(@field);

            if (result.Invalid)
                diagnostics.Enqueue(new InvalidValue(record, property, result.Bad.ToImmutableArray(), range));
            else
                values[i] = result.Value;

            range = new(range.Start.Value + fieldLength, range.End.Value + fieldLength);
        }
        set(record, values);
    }
}
