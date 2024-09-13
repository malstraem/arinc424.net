namespace Arinc424.Converters;

using static System.Globalization.NumberStyles;

/// <summary>
/// See section 5.141 and 5.142.
/// </summary>
internal abstract class StartingCoordinatesConverter : IStringConverter<Coordinates>
{
    public static Result<Coordinates> Convert(ReadOnlySpan<char> @string)
    {
        var sub = @string[1..3];

        if (!double.TryParse(sub, None, null, out double latitude))
            return sub;

        char sign = @string[0];

        if (sign is 'S')
            latitude = -latitude;
        else if (sign is not 'N')
            return sign;

        sub = @string[4..7];

        if (!double.TryParse(sub, None, null, out double longitude))
            return sub;

        sign = @string[3];

        if (sign is 'W')
            longitude = -longitude;
        else if (sign is not 'E')
            return sign;

        return new Coordinates(latitude, longitude);
    }
}
