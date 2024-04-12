namespace Arinc424.Converters;

internal abstract class LocalizerFrequencyConverter : IStringConverter<LocalizerFrequencyConverter, int>
{
    public static int Convert(ReadOnlySpan<char> @string) => int.Parse(@string) * 10;
}
