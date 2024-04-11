namespace Arinc424.Converters;

internal abstract class HundredthsConverter : IStringConverter<HundredthsConverter, float>
{
    public static float Convert(ReadOnlySpan<char> @string) => float.Parse(@string) / 100;
}
