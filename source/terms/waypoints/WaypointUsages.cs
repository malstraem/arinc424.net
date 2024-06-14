namespace Arinc424.Waypoints.Terms;

/// <summary>
/// <c>Waypoint Usage</c> field.
/// </summary>
/// <remarks>See section 5.82.</remarks>
[String, Flags, Decode<WaypointUsagesConverter, WaypointUsages>]
public enum WaypointUsages : byte
{
    Unknown = 0,
    /// <summary>
    /// RNAV.
    /// </summary>
    [Map('R')] AreaNavigation = 1,
    /// <summary>
    /// LO Altitude.
    /// </summary>
    [Offset, Map('B')] LowHigh = Low | High,
    /// <summary>
    /// HI Altitude.
    /// </summary>
    [Map('H')] High = 1 << 1,
    /// <summary>
    /// LO Altitude.
    /// </summary>
    [Map('L')] Low = 1 << 2,
    /// <summary>
    /// Terminal Use Only.
    /// </summary>
    [Map] Terminal = 1 << 3
}
