namespace Arinc424.Ground;

using Procedures;

/**<summary>
<c>Airport and Heliport TAA</c> primary record.
</summary>
<remarks>See section 4.1.31.1 and 4.2.6.1.</remarks>*/
[Section('P', 'K', subInd: 13), Section('H', 'K', subInd: 13)]

[Port(7, 10), Icao(11, 12), Continuous(30)]
public class ArrivalAltitude : Record424
{
    public Port Port { get; set; }

    [Known(14, 19)]
    public Approach Approach { get; set; }

    [Type(27, 28)]
    [Polymorph(20, 24), Icao(25, 26)]
    public Fix Fix { get; set; }

    /// <inheritdoc cref="Terms.FixPosition"/>
    [Character(29)]
    public Terms.FixPosition FixPosition { get; set; }

    [Field(33, 46), Count(6)]
    [Decode<ArrivalSectorConverter, Terms.ArrivalSector>]
    public Terms.ArrivalSector[] Sectors { get; set; }

    /// <inheritdoc cref="Arinc424.CourseType"/>
    [Character(120)]
    public CourseType CourseType { get; set; }
}
