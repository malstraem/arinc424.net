namespace Arinc.Spec424.Terms.Converters;

internal class WaypointTypeConverter : IStringConverter
{
    public static object Convert(string @string)
    {
        var first = @string[0] switch
        {
            'A' => WaypointType.ArcCenter,
            'C' => WaypointType.CombinedIntersection,
            'I' => WaypointType.ChartedIntersection,
            'M' => WaypointType.MiddleInnerMarker,
            'N' => WaypointType.NonDirectionalBeacon,
            'O' => WaypointType.OuterBackMarker,
            'R' => WaypointType.NamedDmeIntersection,
            'U' => WaypointType.AirwayIntersection,
            'V' => WaypointType.VisualFlightRule,
            'W' => WaypointType.AreaNavigation,
            _ => WaypointType.Unknown
        };

        var second = @string[1] switch
        {
            'A' => WaypointType.FinalApproach,
            'B' => WaypointType.InitialFinalApproach,
            'C' => WaypointType.FinalCourseApproach,
            'D' => WaypointType.IntermediateApproach,
            'F' => WaypointType.OffRouteIntersection,
            'I' => WaypointType.InitialApproach,
            'K' => WaypointType.FinalCourseInitialApproach,
            'L' => WaypointType.FinalCourseIntermediateApproach,
            'M' => WaypointType.MissedApproach,
            'N' => WaypointType.InitialMissedApproach,
            'O' => WaypointType.OceanicGateway,
            'P' => WaypointType.Stepdown,
            'R' => WaypointType.NotProcedure,
            'S' => WaypointType.NamedStepdown,
            'U' => WaypointType.VolumeIntersection,
            'V' => WaypointType.FullLatitude,
            'W' => WaypointType.HalfLatitude,
            _ => WaypointType.Unknown
        };

        var third = @string[2] switch
        {
            'D' => WaypointType.DepartureUse,
            'E' => WaypointType.ArrivalUse,
            'F' => WaypointType.ApproachUse,
            'Z' => WaypointType.MultipleProcedureUse,
            'G' => WaypointType.Enroute,
            _ => WaypointType.Unknown
        };

        return first | second | third;
    }
}
