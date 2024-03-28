using Arinc.Spec424.Attributes;
using Arinc.Spec424.Converters;
using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Records;

[Record('E', 'A')]
public class EnrouteWaypoint : Waypoint
{
    /// <inheritdoc cref="WaypointUsages"/>
    [Field(30, 31), Decode<WaypointUsagesConverter>]
    public WaypointUsages Usages { get; init; }
}
