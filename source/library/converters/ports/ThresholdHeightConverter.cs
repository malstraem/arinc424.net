using static System.Globalization.NumberStyles;

namespace Arinc424.Converters;

/// <inheritdoc cref="Ground.PathPoint.ThresholdHeight"/>
internal abstract class ThresholdHeightConverter : IStringConverter<Altitude>
{
    public static Result<Altitude> Convert(ReadOnlySpan<char> @string)
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
            return @string[6..6];
        }
        return new Altitude(height, unit);
    }
}
