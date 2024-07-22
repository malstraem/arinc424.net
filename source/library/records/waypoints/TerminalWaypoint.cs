using Arinc424.Ports;

namespace Arinc424.Waypoints;

/// <summary>
/// <c>Waypoint</c> and <c>Heliport Terminal Waypoint</c> primary record.
/// </summary>
/// <remarks>See section 4.1.4.1 and 4.2.2.1.</remarks>
[Section('P', 'C', subsectionIndex: 13)]
[Section('H', 'C', subsectionIndex: 13)]
[Port(7, 10)]
[DebuggerDisplay($"{{{nameof(Identifier)},nq}}, {nameof(Port)} - {{{nameof(Port)}}}")]
public class TerminalWaypoint : Waypoint
{
    [Identifier(7, 10), Icao(11, 12)]
    [Possible<Airport, Heliport>]
    public Port Port { get; set; }
}
