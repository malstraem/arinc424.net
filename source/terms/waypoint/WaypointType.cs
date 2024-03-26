using Arinc.Spec424.Attributes;
using Arinc.Spec424.Terms.Converters;

namespace Arinc.Spec424.Terms;

/// <summary>
/// <c>Waypoint Type (TYPE)</c>. See paragraph 5.42.
/// </summary>
/// <remarks><see cref="DecodeAttribute">Decoded</see> by <see cref="WaypointTypeConverter"/>.</remarks>
[Flags]
public enum WaypointType : int
{
    Unknown = 0,
    /// <summary>
    /// ARC Center Fix.
    /// </summary>
    ArcCenter = 1,
    /// <summary>
    /// Combined Named Intersection and/or named DME Fix and RNAV Waypoint.
    /// </summary>
    CombinedIntersection = 1 << 1,
    /// <summary>
    /// Unnamed, Charted Intersection and/or Unnamed DME Fix
    /// </summary>
    ChartedIntersection = 1 << 2,
    /// <summary>
    /// Middle or Inner Marker as Waypoint.
    /// </summary>
    MiddleInnerMarker = 1 << 3,
    /// <summary>
    /// NDB or Terminal NDB Navaid as Waypoint.
    /// </summary>
    NonDirectionalBeacon = 1 << 4,
    /// <summary>
    /// Outer or Back Marker as Waypoint.
    /// </summary>
    OuterBackMarker = 1 << 5,
    /// <summary>
    /// Named Intersection and/or Named DME Fix.
    /// </summary>
    NamedDmeIntersection = 1 << 6,
    /// <summary>
    /// Uncharted Airway Intersection.
    /// </summary>
    AirwayIntersection = 1 << 7,
    /// <summary>
    /// VFR Waypoint.
    /// </summary>
    VisualFlightRule = 1 << 8,
    /// <summary>
    /// RNAV Waypoint.
    /// </summary>
    AreaNavigation = 1 << 9,
    /// <summary>
    /// Final Approach Fix.
    /// </summary>
    FinalApproach = 1 << 10,
    /// <summary>
    /// Initial Approach Fix and Final Approach Fix.
    /// </summary>
    InitialFinalApproach = 1 << 11,
    /// <summary>
    /// Final Approach Course Fix.
    /// </summary>
    FinalCourseApproach = 1 << 12,
    /// <summary>
    /// Intermediate Approach Fix.
    /// </summary>
    IntermediateApproach = 1 << 13,
    /// <summary>
    /// Off-Route Intersection and/or Off Route DME Fix.
    /// </summary>
    OffRouteIntersection = 1 << 14,
    /// <summary>
    /// Initial Approach Fix.
    /// </summary>
    InitialApproach = 1 << 15,
    /// <summary>
    /// Final Approach Course Fix and Initial Approach Fix.
    /// </summary>
    FinalCourseInitialApproach = 1 << 16,
    /// <summary>
    /// Final Approach Course Fix and Intermediate Approach Fix.
    /// </summary>
    FinalCourseIntermediateApproach = 1 << 17,
    /// <summary>
    /// Missed Approach Fix.
    /// </summary>
    MissedApproach = 1 << 18,
    /// <summary>
    /// Initial Approach Fix and Missed Approach Fix.
    /// </summary>
    InitialMissedApproach = 1 << 19,
    /// <summary>
    /// Oceanic Gateway Fix.
    /// </summary>
    OceanicGateway = 1 << 20,
    /// <summary>
    /// Unnamed Stepdown Fix.
    /// </summary>
    Stepdown = 1 << 21,
    /// <summary>
    /// RF Leg Fix Not at Procedure Fix.
    /// </summary>
    NotProcedure = 1 << 22,
    /// <summary>
    /// Named Stepdown Fix.
    /// </summary>
    NamedStepdown = 1 << 23,
    /// <summary>
    /// FIR/UIR or Controlled Airspace Intersection.
    /// </summary>
    VolumeIntersection = 1 << 24,
    /// <summary>
    /// Latitude/Longitude Fix, Full Degree of Latitude.
    /// </summary>
    FullLatitude = 1 << 25,
    /// <summary>
    /// Latitude/Longitude Fix, Half Degree of Latitude.
    /// </summary>
    HalfLatitude = 1 << 26,
    /// <summary>
    /// Published for use in SID.
    /// </summary>
    DepartureUse = 1 << 27,
    /// <summary>
    /// Published for use in STAR.
    /// </summary>
    ArrivalUse = 1 << 28,
    /// <summary>
    /// Published for use in Approach Procedures.
    /// </summary>
    ApproachUse = 1 << 29,
    /// <summary>
    /// Published for use in Multiple Terminal Procedure Types.
    /// </summary>
    MultipleProcedureUse = 1 << 30,
    /// <summary>
    /// Source Provided Enroute Waypoint.
    /// </summary>
    Enroute = 1 << 31
}
