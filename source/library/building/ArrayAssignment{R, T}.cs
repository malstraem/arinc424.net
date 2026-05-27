using System.Collections.Immutable;
using System.Reflection;

namespace Arinc424.Building;

internal sealed class ArrayAssignment<R, T>
(
    PropertyInfo property,
    Range range,
    DecodeAttribute<T> decode,
    uint count
)
    : RangeAssignment<R>(property, range)
        where R : Record424
        where T : notnull
{
    private readonly uint count = count;

    private readonly DecodeAttribute<T> decode = decode;

    private readonly Action<R, T[]> set = GetCompiledSetter<T[]>(property);

    internal override void Assign(R record, ReadOnlySpan<char> @string, Queue<Diagnostic> diagnostics)
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

        var values = new T[arrayLength];

        for (int i = 0; i < arrayLength; i++)
        {
            var @field = @string[range];

            var result = decode.Convert(@field);

            if (result.Invalid)
            {
                diagnostics.Enqueue(new BadValue
                {
                    Range = range,
                    Record = record,
                    Property = property,
                    Value = result.Bad.ToImmutableArray()
                });
            }
            else
            {
                values[i] = result.Value;
            }
            range = new(range.Start.Value + fieldLength, range.End.Value + fieldLength);
        }
        set(record, values);
    }
}
