using Arinc424.Ports;

namespace Arinc424.Navigation;

using Terms;

#pragma warning disable CS8618

/// <summary>
/// <c>Airport and Heliport Localizer Marker</c> primary record.
/// </summary>
/// <remarks>See section 4.1.13.1.</remarks>
[Section('P', 'M', subsectionIndex: 13), Continuous]
[DebuggerDisplay($"{{{nameof(Identifier)}}}, {nameof(Airport)} - {{{nameof(Airport)}}}")]
public class InstrumentLandingMarker : Geo, IIdentity, IIcao
{
    [Foreign(7, 12)]
    public Airport Airport { get; set; }

    [Field(11, 12)]
    public string IcaoCode { get; set; }

    /// <summary>
    /// <c>Localizer(LOC IDENT)</c> field.
    /// </summary>
    /// <remarks>See section 5.44.</remarks>
    [Field(14, 17)]
    public string Identifier { get; set; }

    /// <inheritdoc cref="MarkerType"/>
    [Field(18, 20)]
    public MarkerType Type { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Frequency']/*"/>
    [Field(23, 27), Float(10)]
    public float Frequency { get; set; }

    [Foreign(7, 12), Foreign(28, 32), Foreign(11, 12)]
    public Runway Runway { get; set; }

    [Field(52, 55), Float(10)]
    public float Bearing { get; set; }

    [Field(56, 74)]
    public Coordinates LocatorCoordinates { get; set; }

    /// <inheritdoc cref="NondirectType"/>
    [Field(75, 76)]
    public NondirectType NavaidType { get; set; }

    /// <inheritdoc cref="NondirectCoverage"/>
    [Character(77)]
    public NondirectCoverage Coverage { get; set; }

    /// <inheritdoc cref="NondirectInfo"/>
    [Character(78)]
    public NondirectInfo Info { get; set; }

    /// <inheritdoc cref="MarkerCollocation"/>
    [Character(79)]
    public MarkerCollocation Collocation { get; set; }

    [Field(80, 84), Obsolete("need more section 5.93 analysis")]
    public string? Facility { get; set; }

    [Field(85, 88)]
    public string? LocatorIdentifier { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='MagneticVariation']/*"/>
    [Field(91, 95), MagneticVariation]
    public float Variation { get; set; }

    /// <summary>
    /// <c>Facility Elevation (FAC ELEV)</c> field.
    /// </summary>
    /// <value>Feet.</value>
    /// <remarks>See section 5.92.</remarks>
    [Field(98, 102), Integer]
    public int Elevation { get; set; }
}
