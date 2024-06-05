using System.Reflection;
using System.Text.RegularExpressions;

using Arinc424.Diagnostics;

namespace Arinc424.Building;

internal sealed class ArrayAssignment<TRecord, TType>(PropertyInfo property, Regex? regex, Range range, CountAttribute<TType> count)
    : RangeAssignment<TRecord>(property, regex, range) where TRecord : Record424 where TType : notnull
{
    private readonly Action<TRecord, TType[]> set = GetCompiledSetter<TType[]>(property, false);

    private readonly CountAttribute<TType> count = count;

    internal override void Assign(TRecord record, ReadOnlySpan<char> @string, Queue<Diagnostic> diagnostics)
        => set(record, count.GetArray(range, @string, diagnostics));
}
