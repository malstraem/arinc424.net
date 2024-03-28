namespace Arinc.Spec424.Converters;

internal class MagneticVariationConverter : IStringConverter
{
    public static object Convert(string @string)
    {
        if (@string.Length != 5)
            throw new ConvertException(@string, "Length of string is not valid");

        if (@string[0] == 'T')
            return 0;

        float degrees = float.Parse(@string[1..3]) + (float.Parse(@string[3..5]) / 100);

        return @string[0] switch
        {
            'E' => degrees,
            'W' => -degrees,
            _ => throw new ConvertException(@string, $"'{@string[0]}' is not valid type of magnetic variation")
        };
    }
}
