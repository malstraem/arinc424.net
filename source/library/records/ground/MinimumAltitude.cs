using Arinc424.Ground.Terms;

namespace Arinc424.Ground;

/**<summary>
<c>Airport and Heliport MSA</c> primary record.
</summary>
<remarks>See section 4.1.20.1 and 4.2.4.</remarks>*/
[Section('P', 'S', subsectionIndex: 13), Section('H', 'S', subsectionIndex: 13)]

[Icao(11, 12), Port(7, 10), ContinuousAttribute(39)]
public class MinimumAltitude : Record424, IMultiple
{
    [Identifier(7, 10)]
    [Possible<Airport, Heliport>]
    public Port Port { get; set; }

    [Type(21, 22)]
    [Identifier(14, 18), Icao(19, 20)]
    public IIdentity Center { get; set; }

    [Character(23)]
    public char? Multiplier { get; set; }

    [Field(43, 53), Count(7)]
    public Sector[] Sectors { get; set; }

    /// <inheritdoc cref="Arinc424.CourseType"/>
    [Character(120)]
    public CourseType CourseType { get; set; }
}
