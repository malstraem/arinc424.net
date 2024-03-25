namespace Arinc.Spec424.Terms.Converters;

internal class WaypointTypeConverter : IStringConverter
{
    public static object Convert(string @string)
    {
        var first = @string[0] switch
        {
            'A' => WaypointType.Airport,
            'E' => WaypointType.Essential,
            'F' => WaypointType.OffAirway,
            'G' => WaypointType.RunwayHelipad,
            'H' => WaypointType.Heliport,
            'N' => WaypointType.NonDirectionalBeacon,
            'P' => WaypointType.Phantom,
            'R' => WaypointType.NonEssential,
            'T' => WaypointType.TransitionEssential,
            'V' => WaypointType.OmnidirectionalStation,
            _ => WaypointType.Unknown
        };

        var second = @string[1] switch
        {
            'B' => WaypointType.EndingLeg,
            'E' => WaypointType.ContinuousSegmentEnd,
            'U' => WaypointType.UnchartedIntersection,
            'Y' => WaypointType.FlyOver,
            _ => WaypointType.Unknown
        };

        var third = @string[2] switch
        {
            'A' => WaypointType.StepdownFinalFix,
            'B' => WaypointType.StepdownIntermediateFix,
            'C' => WaypointType.AtcReportingPoint,
            'G' => WaypointType.OceanicGateway,
            'M' => WaypointType.MissedApproachFirstLeg,
            'R' => WaypointType.TurnFinalApproach,
            'S' => WaypointType.NamedStepdownFix,
            _ => WaypointType.Unknown
        };

        var fourth = @string[3] switch
        {
            'A' => WaypointType.InitialApproachFix,
            'B' => WaypointType.IntermediateApproachFix,
            'C' => WaypointType.HoldInitialApproachFix,
            'D' => WaypointType.InitialApproachFACF,
            'E' => WaypointType.FinalEndPoint,
            'F' => WaypointType.FinalApproachFix,
            'G' => WaypointType.WithoutHolding,
            'H' => WaypointType.WithHolding,
            'I' => WaypointType.FinalApproachCourseFix,
            'M' => WaypointType.MissedApproachPoint,
            'N' => WaypointType.EngineOutDisarmPoint,
            _ => WaypointType.Unknown
        };

        return first | second | third | fourth;
    }
}
