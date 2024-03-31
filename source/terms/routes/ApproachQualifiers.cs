namespace Arinc.Spec424.Terms;

[Flags]
public enum ApproachQualifiers : uint
{
    Unknown = 0u,
    /// <summary>
    /// RNAV Visual Procedure.
    /// </summary>
    AreaNavigationVisual = 1u,
    /// <summary>
    /// DME required.
    /// </summary>
    DistanceEquipment = 1u << 1,
    /// <summary>
    /// GPS (GNSS) required, DME/DME to RNP not authorized.
    /// </summary>
    DistanceEquipmentNotAuthorized = 1u << 2,
    /// <summary>
    /// RNP SAAAR/AR.
    /// </summary>
    NavigationPerformance = 1u << 3,
    /// <summary>
    /// Advanced (RNAV RNP, SAAAR/AR not required).
    /// </summary>
    Advanced = 1u << 4,
    /// <summary>
    /// GBAS Procedure.
    /// </summary>
    GroundBasedAugmentation = 1u << 5,
    /// <summary>
    /// DME not required for Procedure.
    /// </summary>
    DistanceEquipmentNotRequired = 1u << 6,
    /// <summary>
    /// GNSS required.
    /// </summary>
    GlobalNavigation = 1u << 7,
    /// <summary>
    /// GPS (GNSS) or DME/DME to RNP required.
    /// </summary>
    GlobalNavigationDistanceEquipment = 1u << 8,

    /// <summary>
    /// DME/DME Required for Procedure.
    /// </summary>
    AreaNavigationDistanceEquipment = 1u << 9,
    /// <summary>
    /// RNAV, Sensor Not Specified.
    /// </summary>
    SensorNotSpecified = 1u << 10,
    /// <summary>
    /// VOR/DME RNAV.
    /// </summary>
    AreaNavigation = 1u << 11,
    /// <summary>
    /// RNAV Procedure that Requires FAS Data Block.
    /// </summary>
    FinalApproachSegmentDataBlock = 1u << 12,
    /// <summary>
    /// Primary Missed Approach.
    /// </summary>
    PrimaryMissed = 1u << 13,
    /// <summary>
    /// Secondary Missed Approach.
    /// </summary>
    SecondaryMissed = 1u << 14,
    /// <summary>
    /// Engine Out Missed Approach.
    /// </summary>
    EngineOutMissed = 1u << 15,
    /// <summary>
    /// Procedure with Circle-to-land Minimums.
    /// </summary>
    CircleToLand = 1u << 16,
    /// <summary>
    /// Helicopter with Straight-in Minimums.
    /// </summary>
    HelicopterStraightIn = 1u << 17,
    /// <summary>
    /// Helicopter with Circle-to-land Minimums.
    /// </summary>
    HelicopterCircleToLand = 1u << 18,
    /// <summary>
    /// Helicopter with Helicopter Landing Minimums.
    /// </summary>
    HelicopterLanding = 1u << 19,
    /// <summary>
    /// Procedure with Straight-in Minimums.
    /// </summary>
    StraightIn = 1u << 20,
    /// <summary>
    /// Procedure with VMC minimums.
    /// </summary>
    VisualMeteoConditions = 1u << 21
}
