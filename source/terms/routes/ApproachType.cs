namespace Arinc.Spec424.Terms;

/// <summary>
/// <c>Route Type (RT TYPE)</c> -> <c>Approach Route Type Description</c> character.
/// </summary>
/// <remarks>See table 5-7.</remarks>
public enum ApproachType : byte
{
    Unknown,
    /// <summary>
    /// Approach Transition.
    /// </summary>
    Transition,
    /// <summary>
    /// Localizer/Back course Approach.
    /// </summary>
    LocalizerBackCourse,
    /// <summary>
    /// VORDME Approach.
    /// </summary>
    DistanceEquipment,
    /// <summary>
    /// Flight Management System (FMS) Approach.
    /// </summary>
    FlightManagement,
    /// <summary>
    /// Instrument Guidance System (IGS) Approach.
    /// </summary>
    InstrumentGuidance,
    /// <summary>
    /// Area Navigation (RNAV) Approach with Required Navigation  Performance (RNP) Approach.
    /// </summary>
    AreaNavigationPerformance,
    /// <summary>
    /// Instrument Landing System (ILS) Approach.
    /// </summary>
    InstrumentLanding,
    /// <summary>
    /// GNSS Landing System (GLS) Approach.
    /// </summary>
    GlobalNavigationLanding,
    /// <summary>
    /// Localizer Only (LOC) Approach.
    /// </summary>
    LocalizerOnly,
    /// <summary>
    /// Microwave Landing System (MLS) Approach.
    /// </summary>
    MicrowaveLanding,
    /// <summary>
    /// Non-Directional Beacon (NDB) Approach.
    /// </summary>
    NonDirectional,
    /// <summary>
    /// Global Positioning System (GPS) Approach.
    /// </summary>
    GlobalPositioning,
    /// <summary>
    /// Non-Directional Beacon + DME (NDB+DME) Approach.
    /// </summary>
    NonDirectionalDistanceEquipment,
    /// <summary>
    /// Area Navigation (RNAV) Approach.
    /// </summary>
    AreaNavigation,
    /// <summary>
    /// VOR Approach using VORDME/VORTAC.
    /// </summary>
    DistanceEquipmentTactical,
    /// <summary>
    /// TACAN Approach.
    /// </summary>
    Tactical,
    /// <summary>
    /// Simplified Directional Facility (SDF) Approach.
    /// </summary>
    SimplifiedDirectionalFacility,
    /// <summary>
    /// VOR Approach.
    /// </summary>
    Omnidirectional,
    /// <summary>
    /// Microwave Landing System (MLS), Type A Approach.
    /// </summary>
    TypeA,
    /// <summary>
    /// Localizer Directional Aid (LDA) Approach.
    /// </summary>
    LocalizerDirectionalAid,
    /// <summary>
    /// Microwave Landing System (MLS), Type B and C Approach.
    /// </summary>
    TypeBTypeC,
    /// <summary>
    /// Missed Approach.
    /// </summary>
    Missed
}
