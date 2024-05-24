namespace Arinc424.Converters;

internal abstract class IntConverter : IStringConverter<IntConverter, int>
{
    public static Result<int> Convert(ReadOnlySpan<char> @string)
        => !int.TryParse(@string, out int value) ? new Result<int>($"'{@string}' can't be parsed as an integer.") : value;
}
