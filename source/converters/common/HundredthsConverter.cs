namespace Arinc424.Converters;

internal class HundredthsConverter : IStringConverter<HundredthsConverter, float>
{
    public static float Convert(ReadOnlySpan<char> @string) => float.Parse(@string) / 100;
}
