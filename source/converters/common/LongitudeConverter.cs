namespace Arinc.Spec424.Converters;

internal abstract class LongitudeConverter : IStringConverter<LongitudeConverter, double>
{
    public static double Convert(string @string)
    {
        if (@string.Length != 10)
            throw new ConvertException(@string, "Length of string is not valid");

        double degrees = double.Parse(@string[1..4]);
        double minutes = double.Parse(@string[4..6]);
        double seconds = double.Parse(@string[6..8]);
        double centiseconds = double.Parse(@string[6..10]);

        double longitude = degrees + (minutes / 60) + (seconds / 3600) + (centiseconds / 360000);

        return @string[0] switch
        {
            'E' => longitude,
            'W' => -longitude,
            _ => throw new ConvertException(@string, $"{@string[0]} is not valid symbol to define a sign of longitude")
        };
    }
}
