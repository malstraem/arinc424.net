namespace Arinc424.Attributes;

/// <summary>
/// Specifies that property value is a <c>Required Navigation Performance</c> and will be parsed.
/// </summary>
/// <remarks>See section 5.211.</remarks>
internal sealed class PerformanceAttribute : DecodeAttribute<float>
{
    [Obsolete("todo: try parse")]
    internal override Result<float> Convert(ReadOnlySpan<char> @string)
    {
        float value = float.Parse(@string[..2]);

        int exp = @string[2] - '0';

        return exp != 0 ? value / 10 * exp : value;
    }
}
