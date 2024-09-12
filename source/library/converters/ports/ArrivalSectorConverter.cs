using Arinc424.Ports.Terms;

namespace Arinc424.Converters;

internal abstract class ArrivalSectorConverter : IStringConverter<ArrivalSector>
{
    public static Result<ArrivalSector> Convert(ReadOnlySpan<char> @string)
    {
        var sector = SectorConverter.Convert<ArrivalSector>(@string[..13]);

        if (sector.Invalid)
            return sector;

        var result = BoolConverter.Convert(@string[13]);

        if (result.Invalid)
            return result.Problem;

        sector.Value.TurnRequired = result.Value;

        return sector;
    }
}
