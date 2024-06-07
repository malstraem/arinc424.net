namespace Arinc424.Converters;

internal abstract class LocalizerFrequencyConverter : IStringConverter<int>
{
    public static Result<int> Convert(ReadOnlySpan<char> @string)
    {
        var value = IntConverter.Convert(@string);

        return value.Invalid ? value : value.Value * 10;
    }
}
