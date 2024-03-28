namespace Arinc.Spec424.Terms;

/// <summary>
/// <c>Waypoint Description Code (DESC CODE)</c>.
/// </summary>
/// <remarks>See section 5.17.</remarks>
[Flags]
public enum WaypointDescriptions : uint
{
    Unknown = 0u,
    /// <summary>
    /// Airport as Waypoint.
    /// </summary>
    Airport = 1u,
    /// <summary>
    /// Essential Waypoint.
    /// </summary>
    Essential = 1u << 1,
    /// <summary>
    /// Off Airway Floating Waypoint.
    /// </summary>
    OffAirway = 1u << 2,
    /// <summary>
    /// Runway as Waypoint, Helipad as Waypoint.
    /// </summary>
    RunwayHelipad = 1u << 3,
    /// <summary>
    /// Heliport as Waypoint.
    /// </summary>
    Heliport = 1u << 4,
    /// <summary>
    /// NDB Navaid as Waypoint.
    /// </summary>
    NonDirectionalBeacon = 1u << 5,
    /// <summary>
    /// Phantom Waypoint.
    /// </summary>
    Phantom = 1u << 6,
    /// <summary>
    /// Non-Essential Waypoint.
    /// </summary>
    NonEssential = 1u << 7,
    /// <summary>
    /// Transition Essential Waypoint.
    /// </summary>
    TransitionEssential = 1u << 8,
    /// <summary>
    /// VHF Navaid As Waypoint.
    /// </summary>
    OmnidirectionalStation = 1u << 9,
    /// <summary>
    /// Flyover Waypoint, Ending Leg.
    /// </summary>
    EndingLeg = 1u << 10,
    /// <summary>
    /// End of Continuous Segment.
    /// </summary>
    ContinuousSegmentEnd = 1u << 11,
    /// <summary>
    /// Uncharted Airway Intersection.
    /// </summary>
    UnchartedIntersection = 1u << 12,
    /// <summary>
    /// Fly-Over Waypoint.
    /// </summary>
    FlyOver = 1u << 13,
    /// <summary>
    /// Unnamed Stepdown Fix Final Approach Segment.
    /// </summary>
    StepdownFinalFix = 1u << 14,
    /// <summary>
    /// Unnamed Stepdown Fix Intermediate Approach Segment.
    /// </summary>
    StepdownIntermediateFix = 1u << 15,
    /// <summary>
    /// ATC Compulsory Reporting Point.
    /// </summary>
    AtcReportingPoint = 1u << 16,
    /// <summary>
    /// Oceanic Gateway Waypoint.
    /// </summary>
    OceanicGateway = 1u << 17,
    /// <summary>
    /// First Leg of Missed Approach Procedure.
    /// </summary>
    MissedApproachFirstLeg = 1u << 18,
    /// <summary>
    /// Fix used for turning Final Approach.
    /// </summary>
    TurnFinalApproach = 1u << 19,
    /// <summary>
    /// Named Stepdown Fix.
    /// </summary>
    NamedStepdownFix = 1u << 20,
    /// <summary>
    /// Initial Approach Fix.
    /// </summary>
    InitialApproachFix = 1u << 21,
    /// <summary>
    /// Intermediate Approach Fix.
    /// </summary>
    IntermediateApproachFix = 1u << 22,
    /// <summary>
    /// Holding at Initial Approach Fix.
    /// </summary>
    HoldInitialApproachFix = 1u << 23,
    /// <summary>
    /// Initial Approach Fix at FACF.
    /// </summary>
    InitialApproachFACF = 1u << 24,
    /// <summary>
    /// Final End Point.
    /// </summary>
    FinalEndPoint = 1u << 25,
    /// <summary>
    /// Final Approach Fix.
    /// </summary>
    FinalApproachFix = 1u << 26,
    /// <summary>
    /// Source provided Enroute Waypoint without Holding.
    /// </summary>
    WithoutHolding = 1u << 27,
    /// <summary>
    /// Source provided Enroute Waypoint with Holding.
    /// </summary>
    WithHolding = 1u << 28,
    /// <summary>
    /// Final Approach Course Fix.
    /// </summary>
    FinalApproachCourseFix = 1u << 29,
    /// <summary>
    /// Missed Approach Point.
    /// </summary>
    MissedApproachPoint = 1u << 30,
    /// <summary>
    /// Engine Out SID Missed Approach Disarm Point.
    /// </summary>
    EngineOutDisarmPoint = 1u << 31
}
