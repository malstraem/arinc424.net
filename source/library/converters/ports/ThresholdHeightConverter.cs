using Arinc424.Ports.Terms;

namespace Arinc424.Converters;

using static System.Globalization.NumberStyles;

internal abstract class ThresholdHeightConverter : IStringConverter<ThresholdHeight>
{
    public static Result<ThresholdHeight> Convert(ReadOnlySpan<char> @string)
    {
        AltitudeUnit unit;

        var value = @string[..6];

        if (!float.TryParse(value, None, null, out float height))
            return value;

        char @char = @string[6];

        if (@char is 'F')
        {
            unit = AltitudeUnit.Feet;

            height /= 10;
        }
        else if (@char is 'M')
        {
            unit = AltitudeUnit.Meters;

            height /= 100;
        }
        else
        {
            return @char;
        }
        return new ThresholdHeight(height, unit);
    }
}
