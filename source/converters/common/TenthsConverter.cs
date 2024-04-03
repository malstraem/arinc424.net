namespace Arinc424.Converters;

internal abstract class TenthsConverter : IStringConverter<TenthsConverter, float>
{
    public static float Convert(ReadOnlySpan<char> @string) => float.Parse(@string) / 10;
}
