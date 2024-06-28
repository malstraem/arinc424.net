using Arinc424.Ports;

namespace Arinc424.Waypoints;

/// <inheritdoc />
[Section('P', 'C', subsectionIndex: 13)]
[DebuggerDisplay($"{{{nameof(Identifier)},nq}}, {nameof(Airport)} - {{{nameof(Airport)}}}")]
public class AirportTerminalWaypoint : Waypoint
{
    [Foreign(7, 12), Primary]
    public Airport Airport { get; set; }
}
