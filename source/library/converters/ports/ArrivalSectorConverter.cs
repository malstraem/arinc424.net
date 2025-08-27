namespace Arinc424.Converters;

using Ground.Terms;

internal abstract class ArrivalSectorConverter : IStringConverter<ArrivalSector>
{
    public static Result<ArrivalSector> Convert(ReadOnlySpan<char> @string)
    {
        var sector = SectorConverter.Convert<ArrivalSector>(@string[..13]);

        if (sector.Invalid)
            return sector;

        if (!BoolConverter.TryConvert(@string[13], out var value))
            return @string[13..13];

        sector.Value.TurnRequired = value;

        return sector;
    }
}
