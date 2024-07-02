using Arinc424.Navigation;
using Arinc424.Ports.Terms;
using Arinc424.Waypoints;

namespace Arinc424.Ports;

[Port(7, 10)]
public abstract class MinimumAltitude : Record424
{
    [Type(21, 22)]
    [ForeignExcept<Airport, Omnidirectional, Nondirectional, EnrouteWaypoint>(7, 12)]
    [Foreign(14, 20)]

    [Identifier(14, 18), Icao(19, 20), Port(7, 10)]
    public IIdentity Center { get; set; }

    [Character(23)]
    public char MultipleCode { get; set; }

    [Field(43, 53), Count(7)]
    public Sector[] Sectors { get; set; }

    [Character(120)]
    public CourseType CourseType { get; set; }
}
