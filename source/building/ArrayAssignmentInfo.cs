using System.Reflection;
using System.Text.RegularExpressions;

using Arinc424.Diagnostics;

namespace Arinc424.Building;

internal class ArrayAssignmentInfo(PropertyInfo property, Regex? regex, Range range, CountAttribute count)
    : RangeAssignmentInfo(property, regex, range, null)
{
    private readonly Range range = range;

    private readonly CountAttribute count = count;

    internal override void Process(Record424 record, ReadOnlySpan<char> @string, Queue<Diagnostic> diagnostics)
    {
        object? value = count.GetArray(range, @string, diagnostics);

        Property.SetValue(record, value);
    }
}
