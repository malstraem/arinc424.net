namespace Arinc424.Procedures.Terms;

/// <summary>
/// <c>Route Type (RT TYPE)</c> -> <c>Approach Type</c> character.
/// </summary>
/// <remarks>See section 5.7, Table 5-7.</remarks>
[Char, Transform<ApproachTypeConverter, ApproachType>]
[Description("Route Type (RT TYPE) - Approach Type")]
public enum ApproachType : byte
{
    Unknown,
    /// <summary>
    /// Approach Transition.
    /// </summary>
    [Map('A')] Transition,
    /// <summary>
    /// Localizer/Back course Approach.
    /// </summary>
    [Map('B')] LocalizerBackCourse,
    /// <summary>
    /// VORDME Approach.
    /// </summary>
    [Map('D')] DistanceEquipment,
    /// <summary>
    /// Flight Management System (FMS) Approach.
    /// </summary>
    [Map('F')] FlightManagement,
    /// <summary>
    /// Instrument Guidance System (IGS) Approach.
    /// </summary>
    [Map('G')] InstrumentGuidance,
    /// <summary>
    /// Area Navigation (RNAV) Approach with Required Navigation  Performance (RNP) Approach.
    /// </summary>
    [Map('H')] AreaNavigationPerformance,
    /// <summary>
    /// Instrument Landing System (ILS) Approach.
    /// </summary>
    [Map('I')] InstrumentLanding,
    /// <summary>
    /// GNSS Landing System (GLS) Approach.
    /// </summary>
    [Map('J')] GlobalNavigationLanding,
    /// <summary>
    /// Localizer Only (LOC) Approach.
    /// </summary>
    [Map('L')] LocalizerOnly,
    /// <summary>
    /// Microwave Landing System (MLS) Approach.
    /// </summary>
    [Map('M')] MicrowaveLanding,
    /// <summary>
    /// Non-Directional Beacon (NDB) Approach.
    /// </summary>
    [Map('N')] Nondirectional,
    /// <summary>
    /// Global Positioning System (GPS) Approach.
    /// </summary>
    [Map('P')] GlobalPositioning,
    /// <summary>
    /// Non-Directional Beacon + DME (NDB+DME) Approach.
    /// </summary>
    [Map('Q')] NondirectionalDistanceEquipment,
    /// <summary>
    /// Area Navigation (RNAV) Approach.
    /// </summary>
    [Map('R')] AreaNavigation,
    /// <summary>
    /// VOR Approach using VORDME/VORTAC.
    /// </summary>
    [Map('S')] DistanceEquipmentTactical,
    /// <summary>
    /// TACAN Approach.
    /// </summary>
    [Map('T')] Tactical,
    /// <summary>
    /// Simplified Directional Facility (SDF) Approach.
    /// </summary>
    [Map('U')] SimplifiedDirectionalFacility,
    /// <summary>
    /// VOR Approach.
    /// </summary>
    [Map('V')] Omnidirectional,
    /// <summary>
    /// Microwave Landing System (MLS), Type A Approach.
    /// </summary>
    [Map('W')] Alpha,
    /// <summary>
    /// Localizer Directional Aid (LDA) Approach.
    /// </summary>
    [Map('X')] LocalizerDirectionalAid,
    /// <summary>
    /// Microwave Landing System (MLS), Type B and C Approach.
    /// </summary>
    [Map('Y')] BravoCharlie,
    /// <summary>
    /// Missed Approach.
    /// </summary>
    [Map('Z')] Missed
}
