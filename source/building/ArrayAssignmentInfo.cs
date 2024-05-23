using System.Reflection;
using System.Text.RegularExpressions;

namespace Arinc424.Building;

internal class ArrayAssignmentInfo(PropertyInfo property, Regex? regex, Range range, CountAttribute count) : AssignmentInfo(property, regex)
{
    private readonly Range range = range;

    private readonly CountAttribute count = count;

    public void Process(Record424 record)
    {
        ReadOnlySpan<char> @string = record.Source;

        object? value = count.GetArray(range, @string);

        Property.SetValue(record, value);
    }
}
