namespace Arinc424.Waypoints.Terms;

/// <summary>
/// <c>Waypoint Type (TYPE)</c> field.
/// </summary>
/// <remarks>See section 5.42.</remarks>
[String, Flags, Decode<WaypointTypesConverter, WaypointTypes>]
[Description("Waypoint Type (TYPE)")]
public enum WaypointTypes : ulong
{
    Unknown = 0,
    /// <summary>
    /// ARC Center Fix.
    /// </summary>
    [Map('A')] ArcCenter = 1,
    /// <summary>
    /// Combined Named Intersection and/or named DME Fix and RNAV Waypoint.
    /// </summary>
    [Map('C')] CombinedIntersection = 1ul << 1,
    /// <summary>
    /// Unnamed, Charted Intersection and/or Unnamed DME Fix.
    /// </summary>
    [Map('I')] ChartedIntersection = 1ul << 2,
    /// <summary>
    /// Middle or Inner Marker as Waypoint.
    /// </summary>
    [Map('M')] MiddleInnerMarker = 1ul << 3,
    /// <summary>
    /// NDB or Terminal NDB Navaid as Waypoint.
    /// </summary>
    [Map('N')] NondirectionalBeacon = 1ul << 4,
    /// <summary>
    /// Outer or Back Marker as Waypoint.
    /// </summary>
    [Map('O')] OuterBackMarker = 1ul << 5,
    /// <summary>
    /// Named Intersection and/or Named DME Fix.
    /// </summary>
    [Map('R')] NamedDmeIntersection = 1ul << 6,
    /// <summary>
    /// Uncharted Airway Intersection.
    /// </summary>
    [Map('U')] AirwayIntersection = 1ul << 7,
    /// <summary>
    /// VFR Waypoint.
    /// </summary>
    [Map('V')] VisualFlightRule = 1ul << 8,
    /// <summary>
    /// RNAV Waypoint.
    /// </summary>
    [Map('W')] AreaNavigation = 1ul << 9,
    /// <summary>
    /// Final Approach Fix.
    /// </summary>
    [Offset, Map('A')] FinalApproach = 1ul << 10,
    /// <summary>
    /// Initial Approach Fix and Final Approach Fix.
    /// </summary>
    [Map('B')] InitialFinalApproach = 1ul << 11,
    /// <summary>
    /// Final Approach Course Fix.
    /// </summary>
    [Map('C')] FinalCourseApproach = 1ul << 12,
    /// <summary>
    /// Intermediate Approach Fix.
    /// </summary>
    [Map('D')] IntermediateApproach = 1ul << 13,
    /// <summary>
    /// Off-Route Intersection and/or Off Route DME Fix.
    /// </summary>
    [Map('F')] OffRouteIntersection = 1ul << 14,
    /// <summary>
    /// Off-Route intersection in the FAA National Reference System.
    /// </summary>
    [Map('E')] OffRouteIntersectionFaa = OffRouteIntersection,
    /// <summary>
    /// Initial Approach Fix.
    /// </summary>
    [Map('I')] InitialApproach = 1ul << 15,
    /// <summary>
    /// Final Approach Course Fix and Initial Approach Fix.
    /// </summary>
    [Map('K')] FinalCourseInitialApproach = 1ul << 16,
    /// <summary>
    /// Final Approach Course Fix and Intermediate Approach Fix.
    /// </summary>
    [Map('L')] FinalCourseIntermediateApproach = 1ul << 17,
    /// <summary>
    /// Missed Approach Fix.
    /// </summary>
    [Map('M')] MissedApproach = 1ul << 18,
    /// <summary>
    /// Initial Approach Fix and Missed Approach Fix.
    /// </summary>
    [Map('N')] InitialMissedApproach = 1ul << 19,
    /// <summary>
    /// Oceanic Gateway Fix.
    /// </summary>
    [Map('O')] OceanicGateway = 1ul << 20,
    /// <summary>
    /// Unnamed Stepdown Fix.
    /// </summary>
    [Map('P')] Stepdown = 1ul << 21,
    /// <summary>
    /// RF Leg Fix Not at Procedure Fix.
    /// </summary>
    [Map('R')] NotAtProcedure = 1ul << 22,
    /// <summary>
    /// Named Stepdown Fix.
    /// </summary>
    [Map('S')] NamedStepdown = 1ul << 23,
    /// <summary>
    /// FIR/UIR or Controlled Airspace Intersection.
    /// </summary>
    [Map('U')] VolumeIntersection = 1ul << 24,
    /// <summary>
    /// Latitude/Longitude Fix, Full Degree of Latitude.
    /// </summary>
    [Map('V')] FullLatitude = 1ul << 25,
    /// <summary>
    /// Latitude/Longitude Fix, Half Degree of Latitude.
    /// </summary>
    [Map('W')] HalfLatitude = 1ul << 26,
    /// <summary>
    /// Published for use in SID.
    /// </summary>
    [Offset, Map('D')] DepartureUse = 1ul << 27,
    /// <summary>
    /// Published for use in STAR.
    /// </summary>
    [Map('E')] ArrivalUse = 1ul << 28,
    /// <summary>
    /// Published for use in Approach Procedures.
    /// </summary>
    [Map('F')] ApproachUse = 1ul << 29,
    /// <summary>
    /// Published for use in Multiple Terminal Procedure Types.
    /// </summary>
    [Map('Z')] MultipleProcedureUse = 1ul << 30,
    /// <summary>
    /// Source Provided Enroute Waypoint.
    /// </summary>
    [Map('G')] Enroute = 1ul << 31,
    Off = 1ul << 32
}
