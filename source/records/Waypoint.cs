using System.Diagnostics;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Terms;
using Arinc.Spec424.Converters;

namespace Arinc.Spec424.Records;

#pragma warning disable CS8618

/// <summary>
/// <c>Waypoint</c> primary record.
/// </summary>
/// <remarks>See section 4.1.4.1</remarks>
[Continuous]
[DebuggerDisplay($"{{{nameof(Identifier)}}}")]
public abstract class Waypoint : Geo, IIcao, IIdentity
{
    /// <summary>
    /// <c>Fix Identifier (FIX IDENT)</c> field.
    /// </summary>
    /// <remarks>See section 5.13</remarks>
    [Field(14, 18), Primary]
    public string Identifier { get; init; }

    [Field(20, 21), Primary]
    public string IcaoCode { get; init; }

    /// <inheritdoc cref="WaypointTypes" path="/summary"/>
    [Field(27, 29), Decode<WaypointTypesConverter>]
    public WaypointTypes Types { get; init; }

    /// <summary> 
    /// <c>Magnetic Variation (MAG VAR, D MAG VAR)</c> field.
    /// </summary>
    /// <remarks>See section 5.39</remarks>
    [Field(75, 79), Decode<MagneticVariationConverter>]
    public float DynamicMagneticVariation { get; init; }

    /// <summary>
    /// <c>Datum Code (DATUM)</c> field.
    /// </summary>
    /// <remarks>See section 5.197</remarks>
    [Field(85, 87)]
    public string? DatumCode { get; init; }

    /// <inheritdoc cref="WaypointNameFormats" path="/summary"/>
    [Field(96, 98), Decode<WaypointNameFormatsConverter>]
    public WaypointNameFormats NameFormats { get; init; }

    /// <summary>
    /// <c>Waypoint Name (NAME)</c> field.
    /// </summary>
    /// <remarks>See section 5.43</remarks>
    [Field(99, 123)]
    public string? Name { get; init; }
}
