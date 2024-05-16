namespace Arinc424.Procedures.Terms;

/// <summary>
/// <c>Route Type (RT TYPE)</c> -> <c>SID Qualifier Description</c> field.
/// </summary>
/// <remarks>See section 5.7, Table 5-5.</remarks>
[String, Flags]
public enum DepartureQualifiers : ushort
{
    Unknown = 0,
    /// <summary>
    /// DME required.
    /// </summary>
    [Map('D')] DistanceEquipment = 1,
    /// <summary>
    /// GNSS required.
    /// </summary>
    [Map('G')] GlobalNavigation = 1 << 1,
    /// <summary>
    /// Radar required.
    /// </summary>
    [Map('R')] Radar = 1 << 2,
    /// <summary>
    /// Helicopter SID from Runway.
    /// </summary>
    [Map('H')] Helicopter = 1 << 3,
    /// <summary>
    /// RNP SAAAR/AR.
    /// </summary>
    [Map('F')] NavPerformance = 1 << 4,

    [Offset]
    /// <summary>
    /// VOR/DME RNAV.
    /// </summary>
    [Map('C')] AreaNavigation = 1 << 5,
    /// <summary>
    /// Database supported RNAV.
    /// </summary>
    [Map('D')] DatabaseAreaNavigation = 1 << 6,
    /// <summary>
    /// FMS required.
    /// </summary>
    [Map('F')] FlightManagement = 1 << 7,
    /// <summary>
    /// Conventional Departures.
    /// </summary>
    [Map('G')] Conventional = 1 << 8
}
