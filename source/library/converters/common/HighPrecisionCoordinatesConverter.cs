using static System.Globalization.NumberStyles;

namespace Arinc424.Converters;

/**<summary>
See section 5.267 and 5.268.
</summary>*/
internal abstract class HighPrecisionCoordinatesConverter : IStringConverter<Coordinates>
{
    public static Result<Coordinates> Convert(ReadOnlySpan<char> @string)
    {
        var sub = @string[0..11];

        if (!double.TryParse(sub[1..3], None, null, out double degrees)
          | !double.TryParse(sub[3..5], None, null, out double minutes)
          | !double.TryParse(sub[5..11], None, null, out double decimilliseconds))
        {
            return sub;
        }

        double latitude = degrees + (minutes / 60) + (decimilliseconds / 36000000);

        char sign = sub[0];

        if (sign is 'S')
            latitude = -latitude;
        else if (sign is not 'N')
            return sub[0..0];

        sub = @string[11..23];

        if (!double.TryParse(sub[1..4], None, null, out degrees)
          | !double.TryParse(sub[4..6], None, null, out minutes)
          | !double.TryParse(sub[6..12], None, null, out decimilliseconds))
        {
            return sub;
        }

        double longitude = degrees + (minutes / 60) + (decimilliseconds / 36000000);

        sign = sub[0];

        if (sign is 'W')
            longitude = -longitude;
        else if (sign is not 'E')
            return sub[0..0];

        return new Coordinates(latitude, longitude);
    }
}
