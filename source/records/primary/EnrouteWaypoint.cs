using Arinc.Spec424.Attributes;
using Arinc.Spec424.Terms.Converters;
using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Records;

[Record('E', 'A')]
public class EnrouteWaypoint : Waypoint
{
    /// <inheritdoc cref="WaypointUsage"/>
    [Field(30, 31), Decode<WaypointUsageConverter>]
    public WaypointUsage Usage { get; init; }
}
