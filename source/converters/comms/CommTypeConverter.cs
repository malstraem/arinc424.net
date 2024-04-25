using Arinc424.Comms.Terms;

namespace Arinc424.Converters;

internal abstract class CommTypeConverter : IStringConverter<CommTypeConverter, CommType>
{
    public static CommType Convert(ReadOnlySpan<char> @string) => @string switch
    {
        "ACC" => CommType.Area,
        "ACP" => CommType.Airlift,
        "AIR" => CommType.Air,
        "APP" => CommType.Approach,
        "ARR" => CommType.Arrival,
        "ASO" => CommType.SurfaceObserving,
        "ATI" => CommType.TerminalInfoService,
        "AWI" => CommType.WeatherBroadcast,
        "AWO" => CommType.WeatherObserving,
        "AWS" => CommType.WeatherServices,
        "CBA" => CommType.Bravo,
        "CCA" => CommType.Charlie,
        "CLD" => CommType.DeliveryClearance,
        "CPT" => CommType.PreTaxiClearance,
        "CTA" => CommType.ControlArea,
        "CTF" => CommType.CommonTrafficAdvisory,
        "CTL" => CommType.Control,
        "DEP" => CommType.Departure,
        "DIR" => CommType.Director,
        "EFS" => CommType.FlightAdvisory,
        "EMR" => CommType.Emergency,
        "FSS" => CommType.FlightService,
        "GCO" => CommType.GroundOutlet,
        "GND" => CommType.Ground,
        "GTE" => CommType.Gate,
        "HEL" => CommType.Helicopter,
        "INF" => CommType.Information,
        "MBZ" => CommType.BroadcastZone,
        "MIL" => CommType.Military,
        "MUL" => CommType.Multicom,
        "OPS" => CommType.Operations,
        "PAL" => CommType.ActivatedLighting,
        "RDO" => CommType.Radio,
        "RDR" => CommType.Radar,
        "RFS" => CommType.RemoteFlightService,
        "RMP" => CommType.RampTaxi,
        "RSA" => CommType.RadarService,
        "TCA" => CommType.TerminalControlArea,
        "TMA" => CommType.TerminalManeuveringArea,
        "TML" => CommType.Terminal,
        "TRS" => CommType.TerminalRadarService,
        "TWE" => CommType.TranscriberWeatherBroadcast,
        "TWR" => CommType.Tower,
        "UAC" => CommType.UpperArea,
        "UNI" => CommType.Unicom,
        "VOL" => CommType.Volmet,
        _ => CommType.Unknown
    };
}
