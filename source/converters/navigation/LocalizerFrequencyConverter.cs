namespace Arinc424.Converters;

internal abstract class LocalizerFrequencyConverter : IStringConverter<LocalizerFrequencyConverter, int>
{
    public static Result<int> Convert(ReadOnlySpan<char> @string)
    {
        var value = IntConverter.Convert(@string);

        if (value.IsError)
            return value;

        return value.Value * 10;
    }
}
