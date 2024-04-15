using Arinc424.Attributes;
using Arinc424.Ports;

namespace Arinc424.Waypoints;

#pragma warning disable CS8618

/// <inheritdoc />
[Section('P', 'C', subsectionIndex: 13)]
public class AirportTerminalWaypoint : Waypoint
{
    [Foreign(7, 12), Primary]
    public Airport Airport { get; set; }
}
