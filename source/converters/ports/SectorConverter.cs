using Arinc424.Ports.Terms;

namespace Arinc424.Converters;

internal abstract class SectorConverter : IStringConverter<Sector>
{
    public static Result<Sector> Convert(ReadOnlySpan<char> @string) => Convert<Sector>(@string);

    public static Result<TSector> Convert<TSector>(ReadOnlySpan<char> @string) where TSector : Sector, new()
    {
        string? problem = null;

        var sectorization = SectorizationConverter.Convert(@string[..6]);

        if (sectorization.Invalid)
            problem = sectorization.Problem;

        if (!int.TryParse(@string[6..9], out int altitude))
            problem += $"Altitude '{@string[6..9]}' can't be parsed.";

        if (!int.TryParse(@string[9..], out int radius))
            problem += $"Radius '{@string[9..]}' can't be parsed.";

        return problem is null ? new TSector() { Sectorization = sectorization.Value, Altitude = altitude, Radius = radius } : problem;
    }
}
