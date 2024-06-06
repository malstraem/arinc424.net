using System.Reflection;
using System.Text.RegularExpressions;

using Arinc424.Diagnostics;

namespace Arinc424.Building;

internal sealed class ArrayAssignment<TRecord, TType>(PropertyInfo property, Regex? regex, Range range, DecodeAttribute<TType> decode, uint count)
    : RangeAssignment<TRecord>(property, regex, range) where TRecord : Record424 where TType : notnull
{
    private readonly uint count = count;

    private readonly DecodeAttribute<TType> decode = decode;

    private readonly Action<TRecord, TType[]> set = GetCompiledSetter<TType[]>(property, false);

    [Obsolete("todo")]
    private TType[] GetArray(Range range, ReadOnlySpan<char> @string, Queue<Diagnostic> diagnostics)
    {
        List<TType> list = [];

        int length = range.End.Value - range.Start.Value;

        for (int i = 0; i < count; i++)
        {
            var @field = @string[range];

            if (@field.IsWhiteSpace())
                break;

            // todo: process error
            list.Add(decode.Convert(@field).Value);

            range = new(range.Start.Value + length, range.End.Value + length);
        }
        return [.. list];
    }

    internal override void Assign(TRecord record, ReadOnlySpan<char> @string, Queue<Diagnostic> diagnostics) => set(record, GetArray(range, @string, diagnostics));
}
