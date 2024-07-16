using Arinc424.Ports.Terms;

namespace Arinc424.Ports;

[Section('P', 'S', subsectionIndex: 13)]
[Section('H', 'S', subsectionIndex: 13)]
[Icao(11, 12), Port(7, 10), Continuous(39)]
public class MinimumAltitude : Record424
{
    [Identifier(7, 10)]
    [Possible<Airport, Heliport>]
    public Port Port { get; set; }

    [Type(21, 22)]
    [Identifier(14, 18), Icao(19, 20)]
    public IIdentity Center { get; set; }

    [Character(23)]
    public char MultipleCode { get; set; }

    [Field(43, 53), Count(7)]
    public Sector[] Sectors { get; set; }

    [Character(120)]
    public CourseType CourseType { get; set; }
}
