namespace Arinc424.Procedures.Terms;

/// <summary>
/// <c>Route Type (RT TYPE)</c> -> <c>SID Qualifier Description</c> field.
/// </summary>
/// <remarks>See table 5-5.</remarks>
[Flags]
public enum DepartureQualifiers : ushort
{
    Unknown = 0,
    /// <summary>
    /// DME required.
    /// </summary>
    DistanceEquipment = 1,
    /// <summary>
    /// GNSS required.
    /// </summary>
    GlobalNavigation = 1 << 1,
    /// <summary>
    /// Radar required.
    /// </summary>
    Radar = 1 << 2,
    /// <summary>
    /// Helicopter SID from Runway.
    /// </summary>
    Helicopter = 1 << 3,
    /// <summary>
    /// RNP SAAAR/AR.
    /// </summary>
    NavPerformance = 1 << 4,
    /// <summary>
    /// VOR/DME RNAV.
    /// </summary>
    AreaNavigation = 1 << 5,
    /// <summary>
    /// Database supported RNAV.
    /// </summary>
    DatabaseAreaNavigation = 1 << 6,
    /// <summary>
    /// FMS required.
    /// </summary>
    FlightManagement = 1 << 7,
    /// <summary>
    /// Conventional Departures.
    /// </summary>
    Conventional = 1 << 8
}
