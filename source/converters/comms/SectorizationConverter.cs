namespace Arinc424.Converters;

internal abstract class SectorizationConverter : IStringConverter<SectorizationConverter, Sectorization>
{
    [Obsolete("todo")]
    public static Result<Sectorization> Convert(ReadOnlySpan<char> @string)
    {
        var start = @string[0..3];
        var end = @string[3..6];

        return new Sectorization
        (
            start: start.IsWhiteSpace() ? 0 : int.Parse(start),
            end: end.IsWhiteSpace() ? 0 : int.Parse(end)
        );
    }
}
