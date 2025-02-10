namespace Arinc424.Waypoints;

using Terms;

/// <summary>
/// <c>Waypoint</c> primary record.
/// </summary>
/// <remarks>See section 4.1.4.1.</remarks>
[Section('E', 'A')]

[Identifier(14, 18), Icao(20, 21), Continuous]

[DebuggerDisplay($"{{{nameof(Identifier)},nq}}")]
public class Waypoint : Fix, INamed
{
    /// <inheritdoc cref="WaypointTypes"/>
    [Field(27, 29)]
    public WaypointTypes Types { get; set; }

    /// <inheritdoc cref="WaypointUsages"/>
    [Field(30, 31)]
    public WaypointUsages Usages { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='MagneticVariation']/*"/>
    [Field(75, 79), Variation]
    public float Variation { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Datum']/*"/>
    [Field(85, 87)]
    public string? Datum { get; set; }

    /// <inheritdoc cref="WaypointNameFormats"/>
    [Field(96, 98)]
    public WaypointNameFormats NameFormats { get; set; }

    /// <summary>
    /// <c>Waypoint Name (NAME)</c> field.
    /// </summary>
    /// <remarks>See section 5.43.</remarks>
    [Field(99, 123)]
    public string? Name { get; set; }
}
