using Arinc424.Waypoints.Terms;

namespace Arinc424.Converters;

internal class WaypointDescriptionsConverter : IStringConverter<WaypointDescriptionsConverter, WaypointDescriptions>
{
    public static WaypointDescriptions Convert(ReadOnlySpan<char> @string) => @string[0] switch
    {
        'A' => WaypointDescriptions.Airport,
        'E' => WaypointDescriptions.Essential,
        'F' => WaypointDescriptions.OffAirway,
        'G' => WaypointDescriptions.RunwayHelipad,
        'H' => WaypointDescriptions.Heliport,
        'N' => WaypointDescriptions.NonDirectionalBeacon,
        'P' => WaypointDescriptions.Phantom,
        'R' => WaypointDescriptions.NonEssential,
        'T' => WaypointDescriptions.TransitionEssential,
        'V' => WaypointDescriptions.OmnidirectionalStation,
        _ => WaypointDescriptions.Unknown
    }
    | @string[1] switch
    {
        'B' => WaypointDescriptions.EndingLeg,
        'E' => WaypointDescriptions.ContinuousSegmentEnd,
        'U' => WaypointDescriptions.UnchartedIntersection,
        'Y' => WaypointDescriptions.FlyOver,
        _ => WaypointDescriptions.Unknown
    }
    | @string[2] switch
    {
        'A' => WaypointDescriptions.StepdownFinalFix,
        'B' => WaypointDescriptions.StepdownIntermediateFix,
        'C' => WaypointDescriptions.AtcReportingPoint,
        'G' => WaypointDescriptions.OceanicGateway,
        'M' => WaypointDescriptions.MissedApproachFirstLeg,
        'R' => WaypointDescriptions.TurnFinalApproach,
        'S' => WaypointDescriptions.NamedStepdownFix,
        _ => WaypointDescriptions.Unknown
    }
    | @string[3] switch
    {
        'A' => WaypointDescriptions.InitialApproachFix,
        'B' => WaypointDescriptions.IntermediateApproachFix,
        'C' => WaypointDescriptions.HoldInitialApproachFix,
        'D' => WaypointDescriptions.InitialApproachFacf,
        'E' => WaypointDescriptions.FinalEndPoint,
        'F' => WaypointDescriptions.FinalApproachFix,
        'G' => WaypointDescriptions.WithoutHolding,
        'H' => WaypointDescriptions.WithHolding,
        'I' => WaypointDescriptions.FinalApproachCourseFix,
        'M' => WaypointDescriptions.MissedApproachPoint,
        'N' => WaypointDescriptions.EngineOutDisarmPoint,
        _ => WaypointDescriptions.Unknown
    };
}
