namespace Arinc424.Converters;

internal abstract class LocalizerFrequencyConverter : IStringConverter<LocalizerFrequencyConverter, int>
{
    public static Result<int> Convert(ReadOnlySpan<char> @string)
    {
        var value = IntConverter.Convert(@string);

        return value.IsError ? value : value.Value * 10;
    }
}
