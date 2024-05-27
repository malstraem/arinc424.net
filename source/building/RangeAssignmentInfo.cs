using System.Reflection;
using System.Text.RegularExpressions;

using Arinc424.Diagnostics;

namespace Arinc424.Building;

[DebuggerDisplay($"{{{nameof(Property)}}} - {{{nameof(range)}}}")]
internal class RangeAssignmentInfo(PropertyInfo property, Regex? regex, Range range, DecodeAttribute? decode) : AssignmentInfo(property, regex)
{
    private readonly Range range = range;

    private readonly DecodeAttribute? decode = decode;

    internal virtual void Process(Record424 record, ReadOnlySpan<char> @string, Queue<Diagnostic> diagnostics)
    {
        var @field = @string[range];

        if (@field.IsWhiteSpace())
        {
            // todo: process nullability by provided conditional settings

            /*if (NullabilityInfo.WriteState is NullabilityState.NotNull)
            {
                diagnostic = new NullDiagnostic(record, $"Property {Property} does not allow blank values.", range);
                return false;
            }*/
            return;
        }

        object? value;

        if (decode is not null)
        {
            var result = decode.Convert(@field);

            if (result.IsError)
            {
                diagnostics.Enqueue(new ValueDiagnostic(record, result.Problem!, range));
                return;
            }
            value = result.Value;
        }
        else
        {
            value = @field.Trim().ToString();
        }
        Property.SetValue(record, value);
    }
}
