namespace Arinc424.Converters;

internal abstract class NavigationPerformanceConverter : IStringConverter<NavigationPerformanceConverter, float>
{
    [Obsolete("todo")]
    public static Result<float> Convert(ReadOnlySpan<char> @string)
    {
        float value = float.Parse(@string[..2]);

        int exp = @string[2] - '0';

        return exp != 0 ? value / 10 * exp : value;
    }
}
