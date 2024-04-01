namespace Arinc.Spec424.Converters;

internal abstract class NavigationPerformanceConverter : IStringConverter<NavigationPerformanceConverter, float>
{
    public static float Convert(string @string)
    {
        float value = float.Parse(@string[..2]);

        int exp = @string[2] - '0';

        if (exp != 0)
            value /= 10 * exp;

        return value;
    }
}
