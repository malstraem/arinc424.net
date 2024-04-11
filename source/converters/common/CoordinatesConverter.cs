namespace Arinc424.Converters;

internal class CoordinatesConverter : IStringConverter<CoordinatesConverter, Coordinates>
{
    public static Coordinates Convert(ReadOnlySpan<char> @string)
    {
        double degrees = double.Parse(@string[1..3]);
        double minutes = double.Parse(@string[3..5]);
        double centiseconds = double.Parse(@string[7..9]);

        double latitude = degrees + (minutes / 60) + (centiseconds / 360000);

        if (@string[0] is 'S')
            latitude = -latitude;

        degrees = double.Parse(@string[10..13]);
        minutes = double.Parse(@string[13..15]);
        centiseconds = double.Parse(@string[15..19]);

        double longitude = degrees + (minutes / 60) + (centiseconds / 360000);

        if (@string[0] is 'W')
            longitude = -longitude;

        return new Coordinates(latitude, longitude);
    }
}
