using System.Diagnostics;

using Arinc424.Attributes;
using Arinc424.Converters;
using Arinc424.Ports;

namespace Arinc424.Navigation;

#pragma warning disable CS8618

/// <summary>
/// <c>Airport and Heliport Localizer Marker</c> primary record.
/// </summary>
/// <remarks>See section 4.1.13.1.</remarks>
[Section('P', 'M', subsectionIndex: 13), Continuous]
[DebuggerDisplay($"{{{nameof(Identifier)}}}, {nameof(Airport)} - {{{nameof(Airport)}}}")]
public class InstrumentLandingMarker : Geo, IIcao, IIdentity
{
    [Foreign(7, 12)]
    public Airport Airport { get; set; }

    [Field(11, 12)]
    public string IcaoCode { get; set; }

    [Field(14, 17)]
    public string Identifier { get; set; }

    [Field(18, 20), Decode<MarkerTypeConverter>]
    public Terms.MarkerType Type { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Frequency']/*"/>
    [Field(23, 27), Decode<TenthsConverter>]
    public float Frequency { get; set; }

    [Foreign(7, 12), Foreign(28, 32), Foreign(11, 12)]
    public Runway Runway { get; set; }

    [Field(52, 55), Decode<TenthsConverter>]
    public float Bearing { get; set; }

    [Field(56, 74), Decode<CoordinatesConverter>]
    public Coordinates LocatorCoordinates { get; set; }

    /// <inheritdoc cref="Terms.NavaidType"/>
    [Field(75, 76), Decode<NondirectionalTypeConverter>]
    public Terms.NavaidType NavaidType { get; set; }

    /// <inheritdoc cref="Terms.NavaidCoverage"/>
    [Character(77), Transform<NondirectionalCoverageConverter>]
    public Terms.NavaidCoverage Coverage { get; set; }

    /// <inheritdoc cref="Terms.NavaidInfo"/>
    [Character(78), Transform<NavaidInfoConverter>]
    public Terms.NavaidInfo Info { get; set; }

    /// <inheritdoc cref="Terms.NavaidCollocation"/>
    [Character(79), Transform<NavaidCollocationConverter>]
    public Terms.NavaidCollocation Collocation { get; set; }

    [Field(80, 84), Obsolete("need more section 5.93 analysis")]
    public string? Facility { get; set; }

    [Field(85, 88)]
    public string? LocatorIdentifier { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='MagneticVariation']/*"/>
    [Field(91, 95), Decode<MagneticVariationConverter>]
    public float MagneticVariation { get; set; }

    /// <summary>
    /// <c>Facility Elevation (FAC ELEV)</c> field.
    /// </summary>
    /// <value>Feet.</value>
    /// <remarks>See section 5.92.</remarks>
    [Field(98, 102), Decode<IntConverter>]
    public int Elevation { get; set; }
}