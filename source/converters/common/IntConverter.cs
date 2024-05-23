namespace Arinc424.Converters;

internal abstract class IntConverter : IStringConverter<IntConverter, int>
{
    public static Result<int> Convert(ReadOnlySpan<char> @string)
    {
        if (!int.TryParse(@string, out int value))
            return new Result<int>($"Value '{value}' can't be parsed.");

        return value;
    }
}
