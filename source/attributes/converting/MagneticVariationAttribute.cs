namespace Arinc424.Attributes;

internal sealed class MagneticVariationAttribute : DecodeAttribute<float>
{
    internal override Result<float> Convert(ReadOnlySpan<char> @string)
    {
        char sign = @string[0];

        if (sign is 'T')
            return 0;

        var value = @string[1..];

        if (!float.TryParse(value, out float degrees))
            return new($"'{value}' can't be parsed as a float.");

        if (sign is 'W')
            return -degrees;
        else if (sign is not 'E')
            return new($"Magnetic variation sign '{sign}' is not valid.");

        return degrees;
    }
}
