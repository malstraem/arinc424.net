namespace Arinc.Spec424.Terms;

/// <summary>
/// <c>Waypoint Type (TYPE)</c> field.
/// </summary>
/// <remarks>See section 5.42.</remarks>
[Flags]
public enum WaypointTypes : uint
{
    Unknown = 0u,
    /// <summary>
    /// ARC Center Fix.
    /// </summary>
    ArcCenter = 1u,
    /// <summary>
    /// Combined Named Intersection and/or named DME Fix and RNAV Waypoint.
    /// </summary>
    CombinedIntersection = 1u << 1,
    /// <summary>
    /// Unnamed, Charted Intersection and/or Unnamed DME Fix.
    /// </summary>
    ChartedIntersection = 1u << 2,
    /// <summary>
    /// Middle or Inner Marker as Waypoint.
    /// </summary>
    MiddleInnerMarker = 1u << 3,
    /// <summary>
    /// NDB or Terminal NDB Navaid as Waypoint.
    /// </summary>
    NonDirectionalBeacon = 1u << 4,
    /// <summary>
    /// Outer or Back Marker as Waypoint.
    /// </summary>
    OuterBackMarker = 1u << 5,
    /// <summary>
    /// Named Intersection and/or Named DME Fix.
    /// </summary>
    NamedDmeIntersection = 1u << 6,
    /// <summary>
    /// Uncharted Airway Intersection.
    /// </summary>
    AirwayIntersection = 1u << 7,
    /// <summary>
    /// VFR Waypoint.
    /// </summary>
    VisualFlightRule = 1u << 8,
    /// <summary>
    /// RNAV Waypoint.
    /// </summary>
    AreaNavigation = 1u << 9,
    /// <summary>
    /// Final Approach Fix.
    /// </summary>
    FinalApproach = 1u << 10,
    /// <summary>
    /// Initial Approach Fix and Final Approach Fix.
    /// </summary>
    InitialFinalApproach = 1u << 11,
    /// <summary>
    /// Final Approach Course Fix.
    /// </summary>
    FinalCourseApproach = 1u << 12,
    /// <summary>
    /// Intermediate Approach Fix.
    /// </summary>
    IntermediateApproach = 1u << 13,
    /// <summary>
    /// Off-Route Intersection and/or Off Route DME Fix.
    /// </summary>
    OffRouteIntersection = 1u << 14,
    /// <summary>
    /// Initial Approach Fix.
    /// </summary>
    InitialApproach = 1u << 15,
    /// <summary>
    /// Final Approach Course Fix and Initial Approach Fix.
    /// </summary>
    FinalCourseInitialApproach = 1u << 16,
    /// <summary>
    /// Final Approach Course Fix and Intermediate Approach Fix.
    /// </summary>
    FinalCourseIntermediateApproach = 1u << 17,
    /// <summary>
    /// Missed Approach Fix.
    /// </summary>
    MissedApproach = 1u << 18,
    /// <summary>
    /// Initial Approach Fix and Missed Approach Fix.
    /// </summary>
    InitialMissedApproach = 1u << 19,
    /// <summary>
    /// Oceanic Gateway Fix.
    /// </summary>
    OceanicGateway = 1u << 20,
    /// <summary>
    /// Unnamed Stepdown Fix.
    /// </summary>
    Stepdown = 1u << 21,
    /// <summary>
    /// RF Leg Fix Not at Procedure Fix.
    /// </summary>
    NotProcedure = 1u << 22,
    /// <summary>
    /// Named Stepdown Fix.
    /// </summary>
    NamedStepdown = 1u << 23,
    /// <summary>
    /// FIR/UIR or Controlled Airspace Intersection.
    /// </summary>
    VolumeIntersection = 1u << 24,
    /// <summary>
    /// Latitude/Longitude Fix, Full Degree of Latitude.
    /// </summary>
    FullLatitude = 1u << 25,
    /// <summary>
    /// Latitude/Longitude Fix, Half Degree of Latitude.
    /// </summary>
    HalfLatitude = 1u << 26,
    /// <summary>
    /// Published for use in SID.
    /// </summary>
    DepartureUse = 1u << 27,
    /// <summary>
    /// Published for use in STAR.
    /// </summary>
    ArrivalUse = 1u << 28,
    /// <summary>
    /// Published for use in Approach Procedures.
    /// </summary>
    ApproachUse = 1u << 29,
    /// <summary>
    /// Published for use in Multiple Terminal Procedure Types.
    /// </summary>
    MultipleProcedureUse = 1u << 30,
    /// <summary>
    /// Source Provided Enroute Waypoint.
    /// </summary>
    Enroute = 1u << 31
}
