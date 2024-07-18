namespace Arinc424.Converters;

using static System.Globalization.NumberStyles;

/// <summary>
/// See section 5.141 and 5.142.
/// </summary>
internal abstract class StartingCoordinatesConverter : IStringConverter<Coordinates>
{
    public static Result<Coordinates> Convert(ReadOnlySpan<char> @string)
    {
        string? problem = null;

        if (!double.TryParse(@string[1..3], None, null, out double latitude))
            problem += $"Latitude '{@string[0..3]}' can't be parsed.";

        char sign = @string[0];

        if (sign is 'S')
            latitude = -latitude;
        else if (sign is not 'N')
            problem += $"Latitude sign '{sign}' is not valid.";

        if (!double.TryParse(@string[4..7], None, null, out double longitude))
            problem += $"Longitude '{@string[4..7]}' can't be parsed.";

        sign = @string[3];

        if (sign is 'W')
            longitude = -longitude;
        else if (sign is not 'E')
            problem += $"Longitude sign '{sign}' is not valid.";

        return problem is null ? new Coordinates(latitude, longitude) : problem;
    }
}
