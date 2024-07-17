namespace Arinc424.Converters;

using static System.Globalization.NumberStyles;

/// <summary>
/// See section 5.267 and 5.268.
/// </summary>
internal abstract class HighPrecisionCoordinatesConverter : IStringConverter<Coordinates>
{
    public static Result<Coordinates> Convert(ReadOnlySpan<char> @string)
    {
        string? problem = null;

        if (!double.TryParse(@string[1..3], None, null, out double degrees)
         | !double.TryParse(@string[3..5], None, null, out double minutes)
         | !double.TryParse(@string[5..11], None, null, out double decimilliseconds))
        {
            problem += $"Latitude '{@string[0..11]}' can't be parsed.";
        }

        double latitude = degrees + (minutes / 60) + (decimilliseconds / 36000000);

        char sign = @string[0];

        if (sign is 'S')
            latitude = -latitude;
        else if (sign is not 'N')
            problem += $"Latitude sign '{sign}' is not valid.";

        if (!double.TryParse(@string[12..15], None, null, out degrees)
         | !double.TryParse(@string[13..15], None, null, out minutes)
         | !double.TryParse(@string[15..23], None, null, out decimilliseconds))
        {
            problem += $"Longitude '{@string[9..23]}' can't be parsed.";
        }

        double longitude = degrees + (minutes / 60) + (decimilliseconds / 36000000);

        sign = @string[11];

        if (sign is 'W')
            longitude = -longitude;
        else if (sign is not 'E')
            problem += $"Longitude sign '{sign}' is not valid.";

        return problem is null ? new Coordinates(latitude, longitude) : problem;
    }
}
