namespace Arinc.Spec424.Converters;

internal class RnpConverter : IStringConverter
{
    public static object Convert(string @string)
    {
        float value = float.Parse(@string[..2]);

        int exp = int.Parse(@string[2].ToString());

        if (exp != 0)
            value /= 10 * exp;

        return value;
    }
}
