namespace Arinc424.Converters;

internal abstract class MagneticVariationConverter : IStringConverter<MagneticVariationConverter, float>
{
    public static Result<float> Convert(ReadOnlySpan<char> @string)
    {
        char sign = @string[0];

        if (sign is 'T')
            return 0;

        var degrees = TenthsConverter.Convert(@string[1..]);

        if (degrees.IsError)
            return degrees;

        if (sign is 'W')
            return -degrees.Value;
        else if (sign is not 'E')
            return new Result<float>($"Magnetic variation sign '{sign}' is not valid.");

        return degrees;
    }
}
