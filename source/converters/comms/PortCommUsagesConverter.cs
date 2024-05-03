using Arinc424.Comms.Terms;

namespace Arinc424.Converters;

internal abstract class PortCommUsagesConverter : IStringConverter<PortCommUsagesConverter, PortCommUsages>
{
    public static PortCommUsages Convert(ReadOnlySpan<char> @string) => @string[0] switch
    {
        'A' => PortCommUsages.Advisory,
        'C' => PortCommUsages.Community,
        'D' => PortCommUsages.Departure,
        'F' => PortCommUsages.FlightInfo,
        'I' => PortCommUsages.Initial,
        'L' => PortCommUsages.Arrival,
        'S' => PortCommUsages.AerodromeFlightInfo,
        'T' => PortCommUsages.TerminalAreaControl,
        _ => PortCommUsages.Unknown
    }
    | @string[1] switch
    {
        'A' => PortCommUsages.AerodromeTraffic,
        'C' => PortCommUsages.CommonTraffic,
        'M' => PortCommUsages.Mandatory,
        'S' => PortCommUsages.Secondary,
        _ => PortCommUsages.Unknown
    }
    | @string[2] switch
    {
        'D' => PortCommUsages.DirectionFinding,
        'L' => PortCommUsages.NotEnglish,
        'M' => PortCommUsages.Military,
        'P' => PortCommUsages.ControlledLight,
        _ => PortCommUsages.Unknown
    };
}
