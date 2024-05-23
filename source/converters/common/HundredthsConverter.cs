namespace Arinc424.Converters;

internal abstract class HundredthsConverter : IStringConverter<HundredthsConverter, float>
{
    public static Result<float> Convert(ReadOnlySpan<char> @string)
    {
        if (!float.TryParse(@string, out float value))
            return new Result<float>($"Value '{value}' can't be parsed.");

        return value / 100;
    }
}
