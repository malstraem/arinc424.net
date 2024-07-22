namespace Arinc424.Waypoints.Terms;

/// <summary>
/// <c>Waypoint Description Code (DESC CODE)</c> field.
/// </summary>
/// <remarks>See section 5.17.</remarks>
[String, Flags, Decode<WaypointDescriptionsConverter, WaypointDescriptions>]
[Description("Waypoint Description Code (DESC CODE)")]
public enum WaypointDescriptions : ulong
{
    Unknown = 0u,
    /// <summary>
    /// Airport as Waypoint.
    /// </summary>
    [Map('A')] Airport = 1u,
    /// <summary>
    /// Essential Waypoint.
    /// </summary>
    [Map('E')] Essential = 1u << 1,
    /// <summary>
    /// Off Airway Floating Waypoint.
    /// </summary>
    [Map('F')] OffAirway = 1u << 2,
    /// <summary>
    /// Runway as Waypoint, Helipad as Waypoint.
    /// </summary>
    [Map('G')] RunwayHelipad = 1u << 3,
    /// <summary>
    /// Heliport as Waypoint.
    /// </summary>
    [Map('H')] Heliport = 1u << 4,
    /// <summary>
    /// NDB Navaid as Waypoint.
    /// </summary>
    [Map('N')] Nondirectional = 1u << 5,
    /// <summary>
    /// Phantom Waypoint.
    /// </summary>
    [Map('P')] Phantom = 1u << 6,
    /// <summary>
    /// Non-Essential Waypoint.
    /// </summary>
    [Map('R')] Nonessential = 1u << 7,
    /// <summary>
    /// Transition Essential Waypoint.
    /// </summary>
    [Map('T')] TransitionEssential = 1u << 8,
    /// <summary>
    /// VHF Navaid As Waypoint.
    /// </summary>
    [Map('V')] Omnidirectional = 1u << 9,
    /// <summary>
    /// Flyover Waypoint, Ending Leg.
    /// </summary>
    [Offset, Map('B')] Ending = 1u << 10,
    /// <summary>
    /// End of Continuous Segment.
    /// </summary>
    [Map('E')] ContinuousSegmentEnd = 1u << 11,
    /// <summary>
    /// Uncharted Airway Intersection.
    /// </summary>
    [Map('U')] UnchartedIntersection = 1u << 12,
    /// <summary>
    /// Fly-Over Waypoint.
    /// </summary>
    [Map('Y')] FlyOver = 1u << 13,
    /// <summary>
    /// Unnamed Stepdown Fix Final Approach Segment.
    /// </summary>
    [Offset, Map('A')] StepdownFinal = 1u << 14,
    /// <summary>
    /// Unnamed Stepdown Fix Intermediate Approach Segment.
    /// </summary>
    [Map('B')] StepdownIntermediate = 1u << 15,
    /// <summary>
    /// ATC Compulsory Reporting Point.
    /// </summary>
    [Map('C')] ReportingPoint = 1u << 16,
    /// <summary>
    /// Oceanic Gateway Waypoint.
    /// </summary>
    [Map('G')] OceanicGateway = 1u << 17,
    /// <summary>
    /// First Leg of Missed Approach Procedure.
    /// </summary>
    [Map('M')] MissedApproachFirstLeg = 1u << 18,
    /// <summary>
    /// Fix used for turning Final Approach.
    /// </summary>
    [Map('R')] TurnFinalApproach = 1u << 19,
    /// <summary>
    /// Named Stepdown Fix.
    /// </summary>
    [Map('S')] NamedStepdown = 1u << 20,
    /// <summary>
    /// Initial Approach Fix.
    /// </summary>
    [Offset, Map('A')] InitialApproach = 1u << 21,
    /// <summary>
    /// Intermediate Approach Fix.
    /// </summary>
    [Map('B')] IntermediateApproach = 1u << 22,
    /// <summary>
    /// Holding at Initial Approach Fix.
    /// </summary>
    [Map('C')] HoldInitialApproach = 1u << 23,
    /// <summary>
    /// Initial Approach Fix at FACF.
    /// </summary>
    [Map('D')] InitialApproachFacf = 1u << 24,
    /// <summary>
    /// Final End Point.
    /// </summary>
    [Map('E')] FinalEndpoint = 1u << 25,
    /// <summary>
    /// Final Approach Fix.
    /// </summary>
    [Map('F')] FinalApproach = 1u << 26,
    /// <summary>
    /// Source provided Enroute Waypoint without Holding.
    /// </summary>
    [Map('G')] WithoutHolding = 1u << 27,
    /// <summary>
    /// Source provided Enroute Waypoint with Holding.
    /// </summary>
    [Map('H')] WithHolding = 1u << 28,
    /// <summary>
    /// Final Approach Course Fix.
    /// </summary>
    [Map('I')] FinalApproachCourse = 1u << 29,
    /// <summary>
    /// Missed Approach Point.
    /// </summary>
    [Map('M')] MissedApproach = 1u << 30,
    /// <summary>
    /// Engine Out SID Missed Approach Disarm Point.
    /// </summary>
    [Map('N')] EngineOut = 1u << 31,
    /// <summary>
    /// Initial Departure Fix.
    /// </summary>
    [Map('P')] InitialDeparture = 1ul << 32,
    /// <summary>
    /// Quiet Climb SID Restore Point.
    /// </summary>
    [Map('Q')] QuietClimb = 1ul << 33
}
