namespace Arinc.Spec424.Terms.Converters;

internal class WaypointDescriptionConverter : IStringConverter
{
    public static object Convert(string @string)
    {
        var first = @string[0] switch
        {
            'A' => WaypointDescription.Airport,
            'E' => WaypointDescription.Essential,
            'F' => WaypointDescription.OffAirway,
            'G' => WaypointDescription.RunwayHelipad,
            'H' => WaypointDescription.Heliport,
            'N' => WaypointDescription.NonDirectionalBeacon,
            'P' => WaypointDescription.Phantom,
            'R' => WaypointDescription.NonEssential,
            'T' => WaypointDescription.TransitionEssential,
            'V' => WaypointDescription.OmnidirectionalStation,
            _ => WaypointDescription.Unknown
        };

        var second = @string[1] switch
        {
            'B' => WaypointDescription.EndingLeg,
            'E' => WaypointDescription.ContinuousSegmentEnd,
            'U' => WaypointDescription.UnchartedIntersection,
            'Y' => WaypointDescription.FlyOver,
            _ => WaypointDescription.Unknown
        };

        var third = @string[2] switch
        {
            'A' => WaypointDescription.StepdownFinalFix,
            'B' => WaypointDescription.StepdownIntermediateFix,
            'C' => WaypointDescription.AtcReportingPoint,
            'G' => WaypointDescription.OceanicGateway,
            'M' => WaypointDescription.MissedApproachFirstLeg,
            'R' => WaypointDescription.TurnFinalApproach,
            'S' => WaypointDescription.NamedStepdownFix,
            _ => WaypointDescription.Unknown
        };

        var fourth = @string[3] switch
        {
            'A' => WaypointDescription.InitialApproachFix,
            'B' => WaypointDescription.IntermediateApproachFix,
            'C' => WaypointDescription.HoldInitialApproachFix,
            'D' => WaypointDescription.InitialApproachFACF,
            'E' => WaypointDescription.FinalEndPoint,
            'F' => WaypointDescription.FinalApproachFix,
            'G' => WaypointDescription.WithoutHolding,
            'H' => WaypointDescription.WithHolding,
            'I' => WaypointDescription.FinalApproachCourseFix,
            'M' => WaypointDescription.MissedApproachPoint,
            'N' => WaypointDescription.EngineOutDisarmPoint,
            _ => WaypointDescription.Unknown
        };

        return first | second | third | fourth;
    }
}
