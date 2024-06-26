using Arinc424.Ports;

namespace Arinc424.Waypoints;

/// <summary>
/// <c>Heliport Terminal Waypoint</c> primary record.
/// </summary>
/// <remarks>See section 4.2.2.1.</remarks>
[Section('H', 'C', subsectionIndex: 13)]
public class HeliportTerminalWaypoint : Waypoint
{
    [Foreign(7, 12)]
    public Heliport Heliport { get; set; }
}
