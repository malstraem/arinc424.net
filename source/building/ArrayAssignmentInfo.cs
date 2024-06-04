using System.Reflection;
using System.Text.RegularExpressions;

using Arinc424.Diagnostics;

namespace Arinc424.Building;

internal class ArrayAssignmentInfo<TRecord>(PropertyInfo property, Regex? regex, Range range, CountAttribute count)
    : RangeAssignmentInfo<TRecord>(property, regex, range) where TRecord : Record424
{
    private readonly CountAttribute count = count;

    internal override void Process(TRecord record, ReadOnlySpan<char> @string, Queue<Diagnostic> diagnostics)
    {
        object? value = count.GetArray(range, @string, diagnostics);

        Property.SetValue(record, value);
    }
}
