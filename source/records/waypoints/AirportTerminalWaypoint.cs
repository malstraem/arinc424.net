using Arinc424.Ports;

namespace Arinc424.Waypoints;

/// <inheritdoc />
[Section('P', 'C', subsectionIndex: 13), Port(7, 10)]
[DebuggerDisplay($"{{{nameof(Identifier)},nq}}, {nameof(Airport)} - {{{nameof(Airport)}}}")]
public class AirportTerminalWaypoint : Waypoint
{
    [Identifier(7, 10), Icao(11, 12)]
    public Airport Airport { get; set; }
}
