namespace Arinc424.Converters;

internal abstract class ThousandsConverter : IStringConverter<ThousandsConverter, float>
{
    public static float Convert(ReadOnlySpan<char> @string) => float.Parse(@string) / 1000;
}
