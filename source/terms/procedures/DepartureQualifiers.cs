namespace Arinc424.Procedures.Terms;

/// <summary>
/// <c>Route Type (RT TYPE)</c> -> <c>SID Qualifier Description</c> field.
/// </summary>
/// <remarks>See table 5-5.</remarks>
[Flags]
public enum DepartureQualifiers : uint
{
    Unknown = 0u,
    /// <summary>
    /// DME required.
    /// </summary>
    DistanceEquipment = 1u,
    /// <summary>
    /// GNSS required.
    /// </summary>
    GlobalNavigation = 1u << 1,
    /// <summary>
    /// Radar required.
    /// </summary>
    Radar = 1u << 2,
    /// <summary>
    /// Helicopter SID from Runway.
    /// </summary>
    Helicopter = 1u << 3,
    /// <summary>
    /// RNP SAAAR/AR.
    /// </summary>
    NavPerformance = 1u << 4,
    /// <summary>
    /// VOR/DME RNAV.
    /// </summary>
    AreaNavigation = 1u << 5,
    /// <summary>
    /// Database supported RNAV.
    /// </summary>
    DatabaseAreaNavigation = 1u << 6,
    /// <summary>
    /// FMS required.
    /// </summary>
    FlightManagement = 1u << 7,
    /// <summary>
    /// Conventional Departures.
    /// </summary>
    Conventional = 1u << 8,
}
