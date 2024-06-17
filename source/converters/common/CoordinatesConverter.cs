namespace Arinc424.Converters;

/// <summary>
/// See section 5.36 and 5.37.
/// </summary>
internal abstract class CoordinatesConverter : IStringConverter<Coordinates>
{
    public static Result<Coordinates> Convert(ReadOnlySpan<char> @string)
    {
        string? problem = null;

        if (!double.TryParse(@string[1..3], out double degrees)
         | !double.TryParse(@string[3..5], out double minutes)
         | !double.TryParse(@string[5..9], out double centiseconds))
        {
            problem += $"Latitude '{@string[0..9]}' can't be parsed.";
        }

        double latitude = degrees + (minutes / 60) + (centiseconds / 360000);

        char sign = @string[0];

        if (sign is 'S')
            latitude = -latitude;
        else if (sign is not 'N')
            problem += $"Latitude sign '{sign}' is not valid.";

        if (!double.TryParse(@string[10..13], out degrees)
         | !double.TryParse(@string[13..15], out minutes)
         | !double.TryParse(@string[15..19], out centiseconds))
        {
            problem += $"Longitude '{@string[9..19]}' can't be parsed.";
        }

        double longitude = degrees + (minutes / 60) + (centiseconds / 360000);

        sign = @string[9];

        if (sign is 'W')
            longitude = -longitude;
        else if (sign is not 'E')
            problem += $"Longitude sign '{sign}' is not valid.";

        return problem is null ? new Coordinates(latitude, longitude) : problem;
    }
}
