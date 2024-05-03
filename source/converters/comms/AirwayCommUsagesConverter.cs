using Arinc424.Comms.Terms;

namespace Arinc424.Converters;

internal class AirwayCommUsagesConverter : IStringConverter<AirwayCommUsagesConverter, AirwayCommUsages>
{
    public static AirwayCommUsages Convert(ReadOnlySpan<char> @string) => @string[0] switch
    {
        'A' => AirwayCommUsages.AeronauticalInfo,
        'F' => AirwayCommUsages.FlightInfo,
        _ => AirwayCommUsages.Unknown
    }
    | @string[1] switch
    {
        'A' => AirwayCommUsages.AirGround,
        'D' => AirwayCommUsages.Discrete,
        'M' => AirwayCommUsages.Mandatory,
        'S' => AirwayCommUsages.Secondary,
        _ => AirwayCommUsages.Unknown
    }
    | @string[2] switch
    {
        'D' => AirwayCommUsages.DirectionFinding,
        'L' => AirwayCommUsages.NonEnglish,
        'M' => AirwayCommUsages.Military,
        _ => AirwayCommUsages.Unknown
    };
}
