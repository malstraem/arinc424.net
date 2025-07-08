namespace Arinc424.Converters;

using Navigation.Terms;

internal abstract class DeclinationConverter : IStringConverter<Declination>
{
    public static Result<Declination> Convert(ReadOnlySpan<char> @string)
    {
        if (!float.TryParse(@string[1..], out float value))
            return @string;

        char @char = @string[0];

        if (!DeclinationTypeConverter.TryConvert(@char, out var declination))
            return @string;

        if (@char == 'W')
            value = -value;

        return new Declination(value / 10, declination);
    }
}
