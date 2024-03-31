using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Converters;

internal class WaypointTypesConverter : IStringConverter<WaypointTypesConverter, WaypointTypes>
{
    public static WaypointTypes Convert(string @string) => @string[0] switch
    {
        'A' => WaypointTypes.ArcCenter,
        'C' => WaypointTypes.CombinedIntersection,
        'I' => WaypointTypes.ChartedIntersection,
        'M' => WaypointTypes.MiddleInnerMarker,
        'N' => WaypointTypes.NonDirectionalBeacon,
        'O' => WaypointTypes.OuterBackMarker,
        'R' => WaypointTypes.NamedDmeIntersection,
        'U' => WaypointTypes.AirwayIntersection,
        'V' => WaypointTypes.VisualFlightRule,
        'W' => WaypointTypes.AreaNavigation,
        _ => WaypointTypes.Unknown
    }
    | @string[1] switch
    {
        'A' => WaypointTypes.FinalApproach,
        'B' => WaypointTypes.InitialFinalApproach,
        'C' => WaypointTypes.FinalCourseApproach,
        'D' => WaypointTypes.IntermediateApproach,
        'F' => WaypointTypes.OffRouteIntersection,
        'I' => WaypointTypes.InitialApproach,
        'K' => WaypointTypes.FinalCourseInitialApproach,
        'L' => WaypointTypes.FinalCourseIntermediateApproach,
        'M' => WaypointTypes.MissedApproach,
        'N' => WaypointTypes.InitialMissedApproach,
        'O' => WaypointTypes.OceanicGateway,
        'P' => WaypointTypes.Stepdown,
        'R' => WaypointTypes.NotProcedure,
        'S' => WaypointTypes.NamedStepdown,
        'U' => WaypointTypes.VolumeIntersection,
        'V' => WaypointTypes.FullLatitude,
        'W' => WaypointTypes.HalfLatitude,
        _ => WaypointTypes.Unknown
    }
    | @string[2] switch
    {
        'D' => WaypointTypes.DepartureUse,
        'E' => WaypointTypes.ArrivalUse,
        'F' => WaypointTypes.ApproachUse,
        'Z' => WaypointTypes.MultipleProcedureUse,
        'G' => WaypointTypes.Enroute,
        _ => WaypointTypes.Unknown
    };
}
