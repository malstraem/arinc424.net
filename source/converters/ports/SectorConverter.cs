using Arinc424.Ports.Terms;

namespace Arinc424.Converters;

internal abstract class SectorConverter : IStringConverter<SectorConverter, Sector>
{
    public static Result<Sector> Convert(ReadOnlySpan<char> @string)
    {
        string? problem = null;

        var sectorization = SectorizationConverter.Convert(@string[..6]);

        if (sectorization.IsError)
            problem = sectorization.Problem;

        if (!int.TryParse(@string[6..9], out int altitude))
            problem += $"Altitude '{@string[6..9]}' can't be parsed.";

        if (!int.TryParse(@string[9..11], out int radius))
            problem += $"Radius '{@string[9..11]}' can't be parsed.";

        return problem is null ? new Sector(sectorization.Value, altitude, radius) : problem;
    }
}
