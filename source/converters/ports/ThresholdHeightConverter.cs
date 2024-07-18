using Arinc424.Ports.Terms;

namespace Arinc424.Converters;

using static System.Globalization.NumberStyles;

internal abstract class ThresholdHeightConverter : IStringConverter<ThresholdHeight>
{
    public static Result<ThresholdHeight> Convert(ReadOnlySpan<char> @string)
    {
        string? problem = null;

        var unit = AltitudeUnit.Unknown;

        var height = @string[..6];

        if (!float.TryParse(height, None, null, out float value))
            problem = $"Height '{height}' can't be parsed as float.";

        char @char = @string[6];

        if (@char is 'F')
        {
            unit = AltitudeUnit.Feet;

            value /= 10;
        }
        else if (@char is 'M')
        {
            unit = AltitudeUnit.Meters;

            value /= 100;
        }
        else
        {
            problem += $"'{@char}' is not valid TCH unit.";
        }
        return problem is null ? new ThresholdHeight(value, unit) : problem;
    }
}
