using System.Reflection;
using System.Text.RegularExpressions;

namespace Arinc424.Building;

internal class ArrayAssignmentInfo(PropertyInfo property, Regex? regex, Range range, CountAttributeAttribute array) : AssignmentInfo(property, regex)
{
    private readonly Range range = range;

    private readonly CountAttributeAttribute array = array;

    public void Process(Record424 record)
    {
        ReadOnlySpan<char> @string = record.Source;

        object? value = array.GetArray(range, @string);

        Property.SetValue(record, value);
    }
}
