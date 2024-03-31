namespace Arinc.Spec424.Terms;

/// <summary>
/// <c>Waypoint Usage</c> field.
/// </summary>
/// <remarks>See section 5.82.</remarks>
[Flags]
public enum WaypointUsages : byte
{
    Unknown = 0,
    /// <summary>
    /// LO Altitude.
    /// </summary>
    LowAltitude = 1,
    /// <summary>
    /// HI Altitude.
    /// </summary>
    HighAltitude = 1 << 1,
    /// <summary>
    /// Terminal Use Only.
    /// </summary>
    TerminalOnly = 1 << 2,
    /// <summary>
    /// RNAV.
    /// </summary>
    AreaNavigation = 1 << 3
}
