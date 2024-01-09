namespace Arinc.Spec424.Terms.Converters;

internal class LatitudeConverter : IStringConverter
{
    public static object Convert(string @string)
    {
        if (@string.Length == 9)
        {
            double degrees = double.Parse(@string[1..3]);
            double minutes = double.Parse(@string[3..5]);
            double seconds = double.Parse(@string[5..7]);
            double centiseconds = double.Parse(@string[7..9]);

            double latitude = degrees + (minutes / 60) + (seconds / 3600) + (centiseconds / 360000);

            return @string[0] switch
            {
                'N' => latitude,
                'S' => -latitude,
                _ => throw new ConvertException(@string, $"{@string[0]} is not valid symbol to define a sign of latitude")
            };
        }
        throw new ConvertException(@string, "Length of string is not valid");
    }
}
