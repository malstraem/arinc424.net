namespace Arinc424.Attributes;

using static System.Globalization.NumberStyles;

/// <summary>
/// Decodes <c>Magnetic Variation</c>.
/// </summary>
/// <remarks>See section 5.39.</remarks>
internal sealed class VariationAttribute : DecodeAttribute<float>
{
    internal override Result<float> Convert(ReadOnlySpan<char> @string)
    {
        char sign = @string[0];

        if (sign is 'T')
            return 0;

        var value = @string[1..];

        if (!float.TryParse(value, None, null, out float degrees))
            return value;

        if (sign is 'W')
            return -degrees;
        else if (sign is not 'E')
            return sign;

        return degrees;
    }
}
