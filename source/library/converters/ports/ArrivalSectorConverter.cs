using Arinc424.Ports.Terms;

namespace Arinc424.Converters;

internal abstract class ArrivalSectorConverter : IStringConverter<ArrivalSector>
{
    public static Result<ArrivalSector> Convert(ReadOnlySpan<char> @string)
    {
        var sector = SectorConverter.Convert<ArrivalSector>(@string[..13]);

        if (sector.Invalid)
            return sector;

        sector.Value.TurnRequired = BoolConverter.Convert(@string[13]);

        return sector;
    }
}
