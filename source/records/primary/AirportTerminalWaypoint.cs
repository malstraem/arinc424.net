using Arinc.Spec424.Attributes;

namespace Arinc.Spec424.Records;

#pragma warning disable CS8618

[Record('P', 'C')]
public class AirportTerminalWaypoint : Waypoint
{
    [Foreign(7, 12)]
    public Airport Airport { get; init; }
}
