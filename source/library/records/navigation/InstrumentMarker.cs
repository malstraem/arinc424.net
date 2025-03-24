using Arinc424.Ground;

namespace Arinc424.Navigation;

using Terms;

/**<summary>
<c>Airport and Heliport Localizer Marker</c> primary record.
</summary>
<remarks>See section 4.1.13.1.</remarks>*/
[Section('P', 'M', subsectionIndex: 13), Icao(11, 12), Port(7, 10), ContinuousAttribute]

[DebuggerDisplay($"{{{nameof(Identifier)},nq}}, {nameof(Airport)} - {{{nameof(Airport)}}}")]
public class InstrumentMarker : Fix
{
    [Identifier(7, 10)]
    public Airport Airport { get; set; }

    [Identifier(14, 17)]
    public InstrumentLanding InstrumentLanding { get; set; }

    /// <inheritdoc cref="MarkerType"/>
    [Field(18, 20)]
    public MarkerType Type { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Frequency']/*"/>
    [Field(23, 27), Float(10)]
    public float Frequency { get; set; }

    [Identifier(28, 32)]
    public RunwayThreshold Threshold { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='MinorAxis']/*"/>
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

    /**<summary>
    <c>VOR/NDB Identifier (VOR IDENT/NDB IDENT)</c> field.
    </summary>
    <remarks>See section 5.33.</remarks>*/
    [Field(85, 88)]
    public string? LocatorIdentifier { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='MagneticVariation']/*"/>
    [Field(91, 95), Variation]
    public float Variation { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='FacElev']/*"/>
    [Field(98, 102), Integer]
    public int Elevation { get; set; }
}
