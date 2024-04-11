namespace Arinc424.Procedures.Terms;

/// <summary>
/// <c>Route Type (RT TYPE)</c> -> <c>STAR Qualifier Description</c> field.
/// </summary>
/// <remarks>See table 5-6.</remarks>
[Flags]
public enum ArrivalQualifiers : ushort
{
    Unknown = 0,
    /// <summary>
    /// DME required.
    /// </summary>
    DistanceEquipment = 1,
    /// <summary>
    /// Radar required.
    /// </summary>
    Radar = 1 << 1,
    /// <summary>
    /// RF Leg capability required.
    /// </summary>
    ConstantRadius = 1 << 2,
    /// <summary>
    /// GNSS required.
    /// </summary>
    GlobalNavigation = 1 << 3,
    /// <summary>
    /// Helicopter STAR to Runway.
    /// </summary>
    Helicopter = 1 << 4,
    /// <summary>
    /// Continuous Descent STAR.
    /// </summary>
    Continuous = 1 << 5,
    /// <summary>
    /// VOR/DME RNAV.
    /// </summary>
    AreaNavigation = 1 << 6,
    /// <summary>
    /// Database supported RNAV.
    /// </summary>
    DatabaseAreaNavigation = 1 << 7,
    /// <summary>
    /// FMS required.
    /// </summary>
    FlightManagement = 1 << 8,
    /// <summary>
    /// Conventional Arrivals.
    /// </summary>
    Conventional = 1 << 9
}
