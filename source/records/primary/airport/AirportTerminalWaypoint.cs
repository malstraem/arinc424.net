using Arinc.Spec424.Attributes;

namespace Arinc.Spec424.Records;

#pragma warning disable CS8618

/// <inheritdoc />
[Record('P', 'C', subsectionIndex: 13)]
public class AirportTerminalWaypoint : Waypoint
{
    [Foreign(7, 12), Primary]
    public Airport Airport { get; init; }
}
