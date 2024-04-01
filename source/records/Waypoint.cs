using System.Diagnostics;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Terms;
using Arinc.Spec424.Converters;

namespace Arinc.Spec424.Records;

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
    public string Identifier { get; init; }

    [Field(20, 21), Primary]
    public string IcaoCode { get; init; }

    /// <inheritdoc cref="WaypointTypes"/>
    [Field(27, 29), Decode<WaypointTypesConverter>]
    public WaypointTypes Types { get; init; }

    /// <inheritdoc cref="WaypointUsages"/>
    [Field(30, 31), Decode<WaypointUsagesConverter>]
    public WaypointUsages Usages { get; init; }

    /// <include file='Comments.xml' path="doc/member[@name='MagneticVariation']/*"/>
    [Field(75, 79), Decode<MagneticVariationConverter>]
    public float DynamicMagneticVariation { get; init; }

    /// <include file='Comments.xml' path="doc/member[@name='Datum']/*"/>
    [Field(85, 87)]
    public string? DatumCode { get; init; }

    /// <inheritdoc cref="WaypointNameFormats"/>
    [Field(96, 98), Decode<WaypointNameFormatsConverter>]
    public WaypointNameFormats NameFormats { get; init; }

    /// <summary>
    /// <c>Waypoint Name (NAME)</c> field.
    /// </summary>
    /// <remarks>See section 5.43.</remarks>
    [Field(99, 123)]
    public string? Name { get; init; }
}
