using Arinc424.Navigation;
using Arinc424.Ports.Terms;
using Arinc424.Waypoints;

namespace Arinc424.Ports;

[Continuous(30)]
public abstract class ArrivalAltitude : Record424
{
    [Type(27, 28)]
    [ForeignExcept<EnrouteWaypoint, Omnidirectional, Nondirectional>(7, 12), Foreign(20, 26)]

    [Identifier(20, 24), Icao(25, 26), Port(7, 10)]
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
