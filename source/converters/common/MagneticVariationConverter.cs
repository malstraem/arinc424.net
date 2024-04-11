namespace Arinc424.Converters;

internal abstract class MagneticVariationConverter : IStringConverter<MagneticVariationConverter, float>
{
    public static float Convert(ReadOnlySpan<char> @string)
    {
        if (@string[0] == 'T')
            return 0;

        float degrees = float.Parse(@string[1..]) / 10;

        return @string[0] is 'W' ? -degrees : degrees;
    }
}
