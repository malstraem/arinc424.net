namespace Arinc424.Converters;

using static System.Globalization.NumberStyles;

/// <summary>
/// See section 5.36 and 5.37.
/// </summary>
internal abstract class CoordinatesConverter : IStringConverter<Coordinates>
{
    public static Result<Coordinates> Convert(ReadOnlySpan<char> @string)
    {
        var sub = @string[0..9];

        if (!double.TryParse(sub[1..3], None, null, out double degrees)
          | !double.TryParse(sub[3..5], None, null, out double minutes)
          | !double.TryParse(sub[5..9], None, null, out double centiseconds))
        {
            return sub;
        }

        double latitude = degrees + (minutes / 60) + (centiseconds / 360000);

        char sign = sub[0];

        if (sign is 'S')
            latitude = -latitude;
        else if (sign is not 'N')
            return sub[0..0];

        sub = @string[9..19];

        if (!double.TryParse(sub[1..4], None, null, out degrees)
          | !double.TryParse(sub[4..6], None, null, out minutes)
          | !double.TryParse(sub[6..10], None, null, out centiseconds))
        {
            return sub;
        }

        double longitude = degrees + (minutes / 60) + (centiseconds / 360000);

        sign = sub[0];

        if (sign is 'W')
            longitude = -longitude;
        else if (sign is not 'E')
            return sub[0..0];

        return new Coordinates(latitude, longitude);
    }
}
