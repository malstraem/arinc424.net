using System.Reflection;
using System.Text.RegularExpressions;

namespace Arinc424.Building;

[DebuggerDisplay($"{{{nameof(Property)}}} - {{{nameof(index)}}}")]
internal class IndexAssignmentInfo(PropertyInfo property, Regex? regex, int index, TransformAttribute? transform) : AssignmentInfo(property, regex)
{
    private readonly int index = index;

    private readonly TransformAttribute? transform = transform;

    internal void Process(Record424 record)
    {
        char @char = record.Source[index];

        object value = transform is not null ? transform.Convert(@char) : @char;

        Property.SetValue(record, value);
    }
}
