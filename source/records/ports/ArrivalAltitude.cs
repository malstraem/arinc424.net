using Arinc424.Ports.Terms;

namespace Arinc424.Ports;

[Icao(11, 12), Port(7, 10), Continuous(30)]
public abstract class ArrivalAltitude : Record424
{
    [Type(27, 28)]
    [Identifier(20, 24), Icao(25, 26)]
    public Geo Fix { get; set; }

    /// <inheritdoc cref="Terms.FixPosition"/>
    [Character(29)]
    public FixPosition FixPosition { get; set; }

    [Field(33, 46), Count(6)]
    [Decode<ArrivalSectorConverter, ArrivalSector>]
    public ArrivalSector[] Sectors { get; set; }

    [Character(120)]
    public CourseType CourseType { get; set; }
}
