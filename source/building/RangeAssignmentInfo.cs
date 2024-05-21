using System.Reflection;
using System.Text.RegularExpressions;

namespace Arinc424.Building;

[DebuggerDisplay($"{{{nameof(Property)}}} - {{{nameof(range)}}}")]
internal class RangeAssignmentInfo(PropertyInfo property, Regex? regex, Range range, DecodeAttribute? decode) : AssignmentInfo(property, regex)
{
    private readonly Range range = range;

    private readonly DecodeAttribute? decode = decode;

    public void Process(Record424 record)
    {
        ReadOnlySpan<char> @string = record.Source;

        var @field = @string[range];

        object? value = @field.IsWhiteSpace() ? null : decode is not null
            ? decode.Convert(@field)
            : @field.Trim().ToString();

        Property.SetValue(record, value);
    }
}
