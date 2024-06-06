namespace Arinc424.Attributes;

internal sealed class NavigationPerformanceAttribute : DecodeAttribute<float>
{
    [Obsolete("todo: try parse")]
    internal override Result<float> Convert(ReadOnlySpan<char> @string)
    {
        float value = float.Parse(@string[..2]);

        int exp = @string[2] - '0';

        return exp != 0 ? value / 10 * exp : value;
    }
}
