using Arinc424.Attributes;

namespace Arinc424.Waypoints;

/// <summary>
/// <c>Heliport Terminal Waypoint</c> primary record.
/// </summary>
/// <remarks>See section 4.2.2.1.</remarks>
[Record('H', 'C', subsectionIndex: 13)]
[Obsolete("placeholder")]
public class HeliportTerminalWaypoint : Waypoint
{

}