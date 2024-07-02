using Arinc424.Ports;

namespace Arinc424.Waypoints;

/// <inheritdoc />
[Section('P', 'C', subsectionIndex: 13)]
[DebuggerDisplay($"{{{nameof(Identifier)},nq}}, {nameof(Airport)} - {{{nameof(Airport)}}}")]
public class AirportTerminalWaypoint : Waypoint
{
    [Foreign(7, 12), Primary]

    [Identifier(7, 10), Icao(11, 12)]
    public Airport Airport { get; set; }
}
