using Arinc424.Ports.Terms;

namespace Arinc424.Converters;

internal abstract class SectorConverter : IStringConverter<SectorConverter, Sector>
{
    [Obsolete("todo")]
    public static Result<Sector> Convert(ReadOnlySpan<char> @string)
    {
        var sub = @string[..6];

        var sectorization = SectorizationConverter.Convert(sub);

        return sectorization.IsError
            ? new(sectorization.Message!)
            : !int.TryParse(@string[6..9], out int altitude)

                ? new($"Altitude '{@string[6..9]}' cannot be parsed.")
                : !int.TryParse(@string[9..11], out int radius)

                    ? new($"Radius '{@string[9..11]}' cannot be parsed.")
                    : new(new Sector(sectorization.Value, altitude, radius));
    }
}
