namespace Arinc424.Converters;

internal abstract class NavigationPerformanceConverter : IStringConverter<NavigationPerformanceConverter, float>
{
    public static float Convert(ReadOnlySpan<char> @string)
    {
        float value = float.Parse(@string[..2]);

        int exp = @string[2] - '0';

        if (exp != 0)
            value /= 10 * exp;

        return value;
    }
}
