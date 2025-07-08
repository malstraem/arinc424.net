namespace Arinc424.Navigation;

/**<summary>
<c>Airport and Heliport Localizer Marker</c> primary record.
</summary>
<remarks>See section 4.1.13.1.</remarks>*/
[Section('P', 'M', subIndex: 13), Port(7, 10), Icao(11, 12), Continuous]

[DebuggerDisplay($"{{{nameof(Identifier)},nq}}, {nameof(Port)} - {{{nameof(Port)}}}")]
public class InstrumentMarker : Fix
{
    [Identifier(7, 10)]
    public Ground.Port Port { get; set; }

    [Identifier(14, 17)]
    public InstrumentLanding Landing { get; set; }

    /// <inheritdoc cref="Terms.MarkerType"/>
    [Field(18, 20)]
    public Terms.MarkerType Type { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Frequency']/*"/>
    [Field(23, 27), Float(10)]
    public float Frequency { get; set; }

    [Identifier(28, 32)]
    public Ground.RunwayThreshold Threshold { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='MinorAxis']/*"/>
    [Field(52, 55), Float(10)]
    public float Bearing { get; set; }

    [Field(56, 74)]
    public Coordinates LocatorCoordinates { get; set; }

    /// <inheritdoc cref="Terms.NondirectType"/>
    [Field(75, 76)]
    public Terms.NondirectType NavaidType { get; set; }

    /// <inheritdoc cref="Terms.NondirectCoverage"/>
    [Character(77)]
    public Terms.NondirectCoverage Coverage { get; set; }

    /// <inheritdoc cref="Terms.NondirectInfo"/>
    [Character(78)]
    public Terms.NondirectInfo Info { get; set; }

    /// <inheritdoc cref="Terms.MarkerCollocation"/>
    [Character(79)]
    public Terms.MarkerCollocation Collocation { get; set; }

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
