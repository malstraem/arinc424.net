namespace Arinc424.Waypoints;

/**<summary>
<c>Waypoint</c> primary record.
</summary>
<remarks>See section 4.1.4.1.</remarks>*/
[Section('E', 'A')]

[Identifier(14, 18), Icao(20, 21), Continuous]

[DebuggerDisplay($"{{{nameof(Identifier)},nq}}")]
public class Waypoint : Fix, INamed
{
    /// <inheritdoc cref="Terms.WaypointTypes"/>
    [Field(27, 29)]
    public Terms.WaypointTypes Types { get; set; }

    /// <inheritdoc cref="Terms.WaypointUsages"/>
    [Field(30, 31)]
    public Terms.WaypointUsages Usages { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='MagneticVariation']/*"/>
    [Field(75, 79), Variation]
    public float Variation { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Datum']/*"/>
    [Field(85, 87)]
    public string? Datum { get; set; }

    /// <inheritdoc cref="Terms.WaypointNameFormats"/>
    [Field(96, 98)]
    public Terms.WaypointNameFormats NameFormats { get; set; }

    /// <summary><c>Waypoint Name (NAME)</c> field.</summary>
    /// <remarks>See section 5.43.</remarks>
    [Field(99, 123)]
    public string? Name { get; set; }
}
