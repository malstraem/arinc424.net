using Arinc.Spec424.Attributes;
using Arinc.Spec424.Terms.Converters;

namespace Arinc.Spec424.Terms;

/// <summary>
/// <c>Waypoint Usage</c>. See paragraph 5.82.
/// </summary>
/// <remarks><see cref="DecodeAttribute">Decoded</see> by <see cref="WaypointUsageConverter"/>.</remarks>
[Flags]
public enum WaypointUsage : byte
{
    Unknown = 0,
    /// <summary>
    /// HI Altitude.
    /// </summary>
    HighAltitude = 1 << 1,
    /// <summary>
    /// LO Altitude.
    /// </summary>
    LowAltitude = 1 << 2,
    /// <summary>
    /// HI and LO Altitude.
    /// </summary>
    HighLowAltitude = HighAltitude | LowAltitude,
    /// <summary>
    /// Terminal Use Only.
    /// </summary>
    TerminalOnly = 1 << 3,
    /// <summary>
    /// RNAV .
    /// </summary>
    AreaNavigation = 1 << 4,
}
