namespace Arinc424.Converters;

using Ground.Terms;

internal abstract class SectorConverter : IStringConverter<Sector>
{
    public static Result<Sector> Convert(ReadOnlySpan<char> @string) => Convert<Sector>(@string);

    public static Result<TSector> Convert<TSector>(ReadOnlySpan<char> @string) where TSector : Sector, new()
    {
        var sectorization = SectorizationConverter.Convert(@string[..6]);

        if (sectorization.Invalid)
            return sectorization.Bad;

        var sub = @string[6..9];

        if (!int.TryParse(sub, out int altitude))
            return sub;

        sub = @string[9..];

        return !int.TryParse(sub, out int radius)
            ? sub
            : new TSector() { Sectorization = sectorization.Value, Altitude = altitude, Radius = radius };
    }
}
