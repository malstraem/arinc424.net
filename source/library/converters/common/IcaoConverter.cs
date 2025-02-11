namespace Arinc424.Converters;

internal class IcaoConverter : IStringConverter<Icao>
{
    public static Result<Icao> Convert(ReadOnlySpan<char> @string) => new Icao(@string[0], @string[1]);
}
