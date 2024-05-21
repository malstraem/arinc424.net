namespace Arinc424.Converters;

internal abstract class CoordinatesConverter : IStringConverter<CoordinatesConverter, Coordinates>
{
    [Obsolete("todo")]
    public static Coordinates Convert(ReadOnlySpan<char> @string)
    {
        double degrees = double.Parse(@string[1..3]);
        double minutes = double.Parse(@string[3..5]);
        double centiseconds = double.Parse(@string[5..9]);

        double latitude = degrees + (minutes / 60) + (centiseconds / 360000);

        degrees = double.Parse(@string[10..13]);
        minutes = double.Parse(@string[13..15]);
        centiseconds = double.Parse(@string[15..19]);

        double longitude = degrees + (minutes / 60) + (centiseconds / 360000);

        return new Coordinates(@string[0] is 'S' ? -latitude : latitude, @string[9] is 'W' ? -longitude : longitude);
    }
}
