namespace Arinc424.Routing;

/**<summary>
<c>Airways Marker</c> primary record.
</summary>
<remarks>See section 4.1.15.1.</remarks>*/
[Section('E', 'M'), Id(14, 17), Continuous]

[DebuggerDisplay($"{{{nameof(Identifier)},nq}}")]
public class AirwayMarker : Fix, INamed
{
    /**<summary>
    <c>Marker Code (MARKER CODE)</c> field.
    </summary>
    <remarks>See section 5.111.</remarks>*/
    [Field(23, 26)]
    public string MarkerCode { get; set; }

    /// <inheritdoc cref="Terms.MarkerShape"/>
    [Character(28)]
    public Terms.MarkerShape Shape { get; set; }

    /// <inheritdoc cref="Terms.MarkerPower"/>
    [Character(29)]
    public Terms.MarkerPower Power { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='MinorAxis']/*"/>
    [Field(52, 55), Float(10)]
    public float Bearing { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='MagneticVariation']/*"/>
    [Field(75, 79), Variation]
    public float Variation { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='FacElev']/*"/>
    [Field(80, 84), Integer]
    public int Elevation { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Datum']/*"/>
    [Field(85, 87)]
    public string? Datum { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Name']/*"/>
    [Field(94, 123)]
    public string? Name { get; set; }
}
