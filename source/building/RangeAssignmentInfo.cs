using System.Reflection;
using System.Text.RegularExpressions;

namespace Arinc424.Building;

[DebuggerDisplay($"{{{nameof(Property)}}} - {{{nameof(range)}}}")]
internal class RangeAssignmentInfo(PropertyInfo property, Regex? regex, Range range, DecodeAttribute? decode) : AssignmentInfo(property, regex)
{
    private readonly Range range = range;

    private readonly DecodeAttribute? decode = decode;

    public bool TryProcess(Record424 record, out string? message)
    {
        message = null;

        ReadOnlySpan<char> @string = record.Source;

        var @field = @string[range];

        object? value;

        if (@field.IsWhiteSpace())
        {
            return true;
            // todo: diagnostic nullable of property
            // value = null;
        }
        else
        {
            if (decode is null)
            {
                value = @field.Trim().ToString();
            }
            else
            {
                var result = decode.Convert(@field);

                if (result.IsError)
                {
                    message = result.Message;
                    return false;
                }
                else
                {
                    value = result.Value;
                }
            }
        }

        Property.SetValue(record, value);
        return true;
    }
}
