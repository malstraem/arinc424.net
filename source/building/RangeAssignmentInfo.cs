using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text.RegularExpressions;

using Arinc424.Diagnostics;

namespace Arinc424.Building;

[DebuggerDisplay($"{{{nameof(Property)}}} - {{{nameof(range)}}}")]
internal class RangeAssignmentInfo(PropertyInfo property, Regex? regex, Range range, DecodeAttribute? decode) : AssignmentInfo(property, regex)
{
    private readonly Range range = range;

    private readonly DecodeAttribute? decode = decode;

    public bool TryProcess(Record424 record, [NotNullWhen(false)] out Diagnostic? diagnostic)
    {
        diagnostic = null;

        ReadOnlySpan<char> @string = record.Source;

        var @field = @string[range];

        if (@field.IsWhiteSpace())
        {
            return true;
            // todo: diagnostic nullable of property
            // value = null;
        }

        object? value;

        if (decode is null)
        {
            value = @field.Trim().ToString();
        }
        else
        {
            var result = decode.Convert(@field);

            if (result.IsError)
            {
                diagnostic = new RangeDiagnostic(result.Problem!, range);
                return false;
            }
            value = result.Value;
        }

        Property.SetValue(record, value);
        return true;
    }
}
