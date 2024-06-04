namespace Arinc424.Waypoints;

using Terms;

#pragma warning disable CS8618

/// <summary>
/// <c>Waypoint</c> primary record.
/// </summary>
/// <remarks>See section 4.1.4.1.</remarks>
[Continuous]
[DebuggerDisplay($"{{{nameof(Identifier)}}}")]
public abstract class Waypoint : Geo, IIdentity, IIcao, INamed
{
    /// <include file='Comments.xml' path="doc/member[@name='Fix']/*"/>
    [Field(14, 18), Primary]
    public string Identifier { get; set; }

    [Field(20, 21), Primary]
    public string IcaoCode { get; set; }

    /// <inheritdoc cref="WaypointTypes"/>
    [Field(27, 29)]
    public WaypointTypes Types { get; set; }

    /// <inheritdoc cref="WaypointUsages"/>
    [Field(30, 31)]
    public WaypointUsages Usages { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='MagneticVariation']/*"/>
    [Field(75, 79), MagneticVariation]
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
