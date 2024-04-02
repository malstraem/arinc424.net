namespace Arinc424.Procedures.Terms;

/// <summary>
/// <c>Route Type (RT TYPE)</c> -> <c>STAR Qualifier Description</c> field.
/// </summary>
/// <remarks>See table 5-6.</remarks>
[Flags]
public enum ArrivalQualifiers : uint
{
    Unknown = 0u,
    /// <summary>
    /// DME required.
    /// </summary>
    DistanceEquipment = 1u,
    /// <summary>
    /// Radar required.
    /// </summary>
    Radar = 1u << 1,
    /// <summary>
    /// RF Leg capability required.
    /// </summary>
    ConstantRadius = 1u << 2,
    /// <summary>
    /// GNSS required.
    /// </summary>
    GlobalNavigation = 1u << 3,
    /// <summary>
    /// Helicopter STAR to Runway.
    /// </summary>
    Helicopter = 1u << 4,
    /// <summary>
    /// Continuous Descent STAR.
    /// </summary>
    Continuous = 1u << 5,
    /// <summary>
    /// VOR/DME RNAV.
    /// </summary>
    AreaNavigation = 1u << 6,
    /// <summary>
    /// Database supported RNAV.
    /// </summary>
    DatabaseAreaNavigation = 1u << 7,
    /// <summary>
    /// FMS required.
    /// </summary>
    FlightManagement = 1u << 8,
    /// <summary>
    /// Conventional Arrivals.
    /// </summary>
    Conventional = 1u << 9,
}
