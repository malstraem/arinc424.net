namespace Arinc424.Waypoints.Terms;

/// <summary>
/// <c>Waypoint Type (TYPE)</c> field.
/// </summary>
/// <remarks>See section 5.42.</remarks>
[String, Flags, Decode<WaypointTypesConverter, WaypointTypes>]
[Description("Waypoint Type (TYPE)")]
public enum WaypointTypes : uint
{
    Unknown = 0u,
    /// <summary>
    /// ARC Center Fix.
    /// </summary>
    [Map('A')] ArcCenter = 1u,
    /// <summary>
    /// Combined Named Intersection and/or named DME Fix and RNAV Waypoint.
    /// </summary>
    [Map('C')] CombinedIntersection = 1u << 1,
    /// <summary>
    /// Unnamed, Charted Intersection and/or Unnamed DME Fix.
    /// </summary>
    [Map('I')] ChartedIntersection = 1u << 2,
    /// <summary>
    /// Middle or Inner Marker as Waypoint.
    /// </summary>
    [Map('M')] MiddleInnerMarker = 1u << 3,
    /// <summary>
    /// NDB or Terminal NDB Navaid as Waypoint.
    /// </summary>
    [Map('N')] NondirectionalBeacon = 1u << 4,
    /// <summary>
    /// Outer or Back Marker as Waypoint.
    /// </summary>
    [Map('O')] OuterBackMarker = 1u << 5,
    /// <summary>
    /// Named Intersection and/or Named DME Fix.
    /// </summary>
    [Map('R')] NamedDmeIntersection = 1u << 6,
    /// <summary>
    /// Uncharted Airway Intersection.
    /// </summary>
    [Map('U')] AirwayIntersection = 1u << 7,
    /// <summary>
    /// VFR Waypoint.
    /// </summary>
    [Map('V')] VisualFlightRule = 1u << 8,
    /// <summary>
    /// RNAV Waypoint.
    /// </summary>
    [Map('W')] AreaNavigation = 1u << 9,
    /// <summary>
    /// Final Approach Fix.
    /// </summary>
    [Offset, Map('A')] FinalApproach = 1u << 10,
    /// <summary>
    /// Initial Approach Fix and Final Approach Fix.
    /// </summary>
    [Map('B')] InitialFinalApproach = 1u << 11,
    /// <summary>
    /// Final Approach Course Fix.
    /// </summary>
    [Map('C')] FinalCourseApproach = 1u << 12,
    /// <summary>
    /// Intermediate Approach Fix.
    /// </summary>
    [Map('D')] IntermediateApproach = 1u << 13,
    /// <summary>
    /// Off-Route Intersection and/or Off Route DME Fix.
    /// </summary>
    [Map('F')] OffRouteIntersection = 1u << 14,
    /// <summary>
    /// Initial Approach Fix.
    /// </summary>
    [Map('I')] InitialApproach = 1u << 15,
    /// <summary>
    /// Final Approach Course Fix and Initial Approach Fix.
    /// </summary>
    [Map('K')] FinalCourseInitialApproach = 1u << 16,
    /// <summary>
    /// Final Approach Course Fix and Intermediate Approach Fix.
    /// </summary>
    [Map('L')] FinalCourseIntermediateApproach = 1u << 17,
    /// <summary>
    /// Missed Approach Fix.
    /// </summary>
    [Map('M')] MissedApproach = 1u << 18,
    /// <summary>
    /// Initial Approach Fix and Missed Approach Fix.
    /// </summary>
    [Map('N')] InitialMissedApproach = 1u << 19,
    /// <summary>
    /// Oceanic Gateway Fix.
    /// </summary>
    [Map('O')] OceanicGateway = 1u << 20,
    /// <summary>
    /// Unnamed Stepdown Fix.
    /// </summary>
    [Map('P')] Stepdown = 1u << 21,
    /// <summary>
    /// RF Leg Fix Not at Procedure Fix.
    /// </summary>
    [Map('R')] NotAtProcedure = 1u << 22,
    /// <summary>
    /// Named Stepdown Fix.
    /// </summary>
    [Map('S')] NamedStepdown = 1u << 23,
    /// <summary>
    /// FIR/UIR or Controlled Airspace Intersection.
    /// </summary>
    [Map('U')] VolumeIntersection = 1u << 24,
    /// <summary>
    /// Latitude/Longitude Fix, Full Degree of Latitude.
    /// </summary>
    [Map('V')] FullLatitude = 1u << 25,
    /// <summary>
    /// Latitude/Longitude Fix, Half Degree of Latitude.
    /// </summary>
    [Map('W')] HalfLatitude = 1u << 26,
    /// <summary>
    /// Published for use in SID.
    /// </summary>
    [Offset, Map('D')] DepartureUse = 1u << 27,
    /// <summary>
    /// Published for use in STAR.
    /// </summary>
    [Map('E')] ArrivalUse = 1u << 28,
    /// <summary>
    /// Published for use in Approach Procedures.
    /// </summary>
    [Map('F')] ApproachUse = 1u << 29,
    /// <summary>
    /// Published for use in Multiple Terminal Procedure Types.
    /// </summary>
    [Map('Z')] MultipleProcedureUse = 1u << 30,
    /// <summary>
    /// Source Provided Enroute Waypoint.
    /// </summary>
    [Map('G')] Enroute = 1u << 31
}
