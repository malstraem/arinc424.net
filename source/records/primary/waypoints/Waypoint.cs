using System.Diagnostics;

using Arinc424.Attributes;
using Arinc424.Converters;

namespace Arinc424.Waypoints;

#pragma warning disable CS8618

/// <summary>
/// <c>Waypoint</c> primary record.
/// </summary>
/// <remarks>See section 4.1.4.1.</remarks>
[Continuous]
[DebuggerDisplay($"{{{nameof(Identifier)}}}")]
public abstract class Waypoint : Geo, IIcao, IIdentity
{
    /// <include file='Comments.xml' path="doc/member[@name='FixIdentifier']/*"/>
    [Field(14, 18), Primary]
    public string Identifier { get; set; }

    [Field(20, 21), Primary]
    public string IcaoCode { get; set; }

    /// <inheritdoc cref="Terms.WaypointTypes"/>
    [Field(27, 29), Decode<WaypointTypesConverter>]
    public Terms.WaypointTypes Types { get; set; }

    /// <inheritdoc cref="Terms.WaypointUsages"/>
    [Field(30, 31), Decode<WaypointUsagesConverter>]
    public Terms.WaypointUsages Usages { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='MagneticVariation']/*"/>
    [Field(75, 79), Decode<MagneticVariationConverter>]
    public float DynamicMagneticVariation { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Datum']/*"/>
    [Field(85, 87)]
    public string? DatumCode { get; set; }

    /// <inheritdoc cref="Terms.WaypointNameFormats"/>
    [Field(96, 98), Decode<WaypointNameFormatsConverter>]
    public Terms.WaypointNameFormats NameFormats { get; set; }

    /// <summary>
    /// <c>Waypoint Name (NAME)</c> field.
    /// </summary>
    /// <remarks>See section 5.43.</remarks>
    [Field(99, 123)]
    public string? Name { get; set; }
}
