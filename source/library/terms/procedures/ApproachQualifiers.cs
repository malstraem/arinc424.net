namespace Arinc424.Procedures.Terms;

/// <summary>
/// <c>Route Type (RT TYPE)</c> -> <c>Approach Qualifiers</c> field.
/// </summary>
/// <remarks>See section 5.7, Table 5-8.</remarks>
[String, Flags, Decode<ApproachQualifiersConverter, ApproachQualifiers>]
[Description("Route Type (RT TYPE) - Approach Qualifiers")]
public enum ApproachQualifiers : uint
{
    Unknown = 0u,
    /// <summary>
    /// RNAV Visual Procedure.
    /// </summary>
    [Map('B')] AreaNavigationVisual = 1u,
    /// <summary>
    /// DME required.
    /// </summary>
    [Map('D')] DistanceEquipment = 1u << 1,
    /// <summary>
    /// GPS (GNSS) required, DME/DME to RNP not authorized.
    /// </summary>
    [Map('J')] DistanceEquipmentNotAuthorized = 1u << 2,
    /// <summary>
    /// RNP SAAAR/AR.
    /// </summary>
    [Map('F')] NavigationPerformance = 1u << 3,
    /// <summary>
    /// Advanced (RNAV RNP, SAAAR/AR not required).
    /// </summary>
    [Map('A')] Advanced = 1u << 4,
    /// <summary>
    /// GBAS Procedure.
    /// </summary>
    [Map('L')] GroundBasedAugmentation = 1u << 5,
    /// <summary>
    /// DME not required for Procedure.
    /// </summary>
    [Map('N')] DistanceEquipmentNotRequired = 1u << 6,
    /// <summary>
    /// GNSS required.
    /// </summary>
    [Map('P')] GlobalNavigation = 1u << 7,
    /// <summary>
    /// GPS (GNSS) or DME/DME to RNP required.
    /// </summary>
    [Map('R')] GlobalNavigationDistanceEquipment = 1u << 8,
    /// <summary>
    /// DME/DME Required for Procedure.
    /// </summary>
    [Map('T')] AreaNavigationDistanceEquipment = 1u << 9,
    /// <summary>
    /// RNAV, Sensor Not Specified.
    /// </summary>
    [Map('U')] SensorNotSpecified = 1u << 10,
    /// <summary>
    /// VOR/DME RNAV.
    /// </summary>
    [Map('V')] AreaNavigation = 1u << 11,
    /// <summary>
    /// RNAV Procedure that Requires FAS Data Block.
    /// </summary>
    [Map('W')] FinalApproachSegmentDataBlock = 1u << 12,
    /// <summary>
    /// Primary Missed Approach.
    /// </summary>
    [Offset, Map('A')] PrimaryMissed = 1u << 13,
    /// <summary>
    /// Secondary Missed Approach.
    /// </summary>
    [Map('B')] SecondaryMissed = 1u << 14,
    /// <summary>
    /// Engine Out Missed Approach.
    /// </summary>
    [Map('E')] EngineOutMissed = 1u << 15,
    /// <summary>
    /// Procedure with Circle-to-land Minimums.
    /// </summary>
    [Map('C')] CircleToLand = 1u << 16,
    /// <summary>
    /// Helicopter with Straight-in Minimums.
    /// </summary>
    [Map('H')] HelicopterStraightIn = 1u << 17,
    /// <summary>
    /// Helicopter with Circle-to-land Minimums.
    /// </summary>
    [Map('I')] HelicopterCircleToLand = 1u << 18,
    /// <summary>
    /// Helicopter with Helicopter Landing Minimums.
    /// </summary>
    [Map('L')] HelicopterLanding = 1u << 19,
    /// <summary>
    /// Procedure with Straight-in Minimums.
    /// </summary>
    [Map('S')] StraightIn = 1u << 20,
    /// <summary>
    /// Procedure with VMC minimums.
    /// </summary>
    [Map('V')] VisualMeteoConditions = 1u << 21
}
