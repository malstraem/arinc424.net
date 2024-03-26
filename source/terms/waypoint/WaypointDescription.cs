using Arinc.Spec424.Attributes;
using Arinc.Spec424.Terms.Converters;

namespace Arinc.Spec424.Terms;

/// <summary>
/// <c>Waypoint Description Code (DESC CODE)</c>. See paragraph 5.17.
/// </summary>
/// <remarks><see cref="DecodeAttribute">Decoded</see> by <see cref="WaypointDescriptionConverter"/>.</remarks>
[Flags]
public enum WaypointDescription : int
{
    Unknown = 0,
    /// <summary>
    /// Airport as Waypoint.
    /// </summary>
    Airport = 1 << 0,
    /// <summary>
    /// Essential Waypoint.
    /// </summary>
    Essential = 1 << 1,
    /// <summary>
    /// Off Airway Floating Waypoint.
    /// </summary>
    OffAirway = 1 << 2,
    /// <summary>
    /// Runway as Waypoint, Helipad as Waypoint.
    /// </summary>
    RunwayHelipad = 1 << 3,
    /// <summary>
    /// Heliport as Waypoint.
    /// </summary>
    Heliport = 1 << 4,
    /// <summary>
    /// NDB Navaid as Waypoint.
    /// </summary>
    NonDirectionalBeacon = 1 << 5,
    /// <summary>
    /// Phantom Waypoint.
    /// </summary>
    Phantom = 1 << 6,
    /// <summary>
    /// Non-Essential Waypoint.
    /// </summary>
    NonEssential = 1 << 7,
    /// <summary>
    /// Transition Essential Waypoint.
    /// </summary>
    TransitionEssential = 1 << 8,
    /// <summary>
    /// VHF Navaid As Waypoint.
    /// </summary>
    OmnidirectionalStation = 1 << 9,
    /// <summary>
    /// Flyover Waypoint, Ending Leg.
    /// </summary>
    EndingLeg = 1 << 10,
    /// <summary>
    /// End of Continuous Segment.
    /// </summary>
    ContinuousSegmentEnd = 1 << 11,
    /// <summary>
    /// Uncharted Airway Intersection.
    /// </summary>
    UnchartedIntersection = 1 << 12,
    /// <summary>
    /// Fly-Over Waypoint.
    /// </summary>
    FlyOver = 1 << 13,
    /// <summary>
    /// Unnamed Stepdown Fix Final Approach Segment.
    /// </summary>
    StepdownFinalFix = 1 << 14,
    /// <summary>
    /// Unnamed Stepdown Fix Intermediate Approach Segment.
    /// </summary>
    StepdownIntermediateFix = 1 << 15,
    /// <summary>
    /// ATC Compulsory Reporting Point.
    /// </summary>
    AtcReportingPoint = 1 << 16,
    /// <summary>
    /// Oceanic Gateway Waypoint.
    /// </summary>
    OceanicGateway = 1 << 17,
    /// <summary>
    /// First Leg of Missed Approach Procedure.
    /// </summary>
    MissedApproachFirstLeg = 1 << 18,
    /// <summary>
    /// Fix used for turning Final Approach.
    /// </summary>
    TurnFinalApproach = 1 << 19,
    /// <summary>
    /// Named Stepdown Fix.
    /// </summary>
    NamedStepdownFix = 1 << 20,
    /// <summary>
    /// Initial Approach Fix.
    /// </summary>
    InitialApproachFix = 1 << 21,
    /// <summary>
    /// Intermediate Approach Fix.
    /// </summary>
    IntermediateApproachFix = 1 << 22,
    /// <summary>
    /// Holding at Initial Approach Fix.
    /// </summary>
    HoldInitialApproachFix = 1 << 23,
    /// <summary>
    /// Initial Approach Fix at FACF.
    /// </summary>
    InitialApproachFACF = 1 << 24,
    /// <summary>
    /// Final End Point.
    /// </summary>
    FinalEndPoint = 1 << 25,
    /// <summary>
    /// Final Approach Fix.
    /// </summary>
    FinalApproachFix = 1 << 26,
    /// <summary>
    /// Source provided Enroute Waypoint without Holding.
    /// </summary>
    WithoutHolding = 1 << 27,
    /// <summary>
    /// Source provided Enroute Waypoint with Holding.
    /// </summary>
    WithHolding = 1 << 28,
    /// <summary>
    /// Final Approach Course Fix.
    /// </summary>
    FinalApproachCourseFix = 1 << 29,
    /// <summary>
    /// Missed Approach Point.
    /// </summary>
    MissedApproachPoint = 1 << 30,
    /// <summary>
    /// Engine Out SID Missed Approach Disarm Point.
    /// </summary>
    EngineOutDisarmPoint = 1 << 31
}
