using Arinc424.Navigation;
using Arinc424.Ports.Terms;
using Arinc424.Waypoints;

namespace Arinc424.Ports;

#pragma warning disable CS8618

/// <summary>
/// <c>Airport MSA</c> primary record.
/// </summary>
/// <remarks>See section 4.1.20.1.</remarks>
[Section('P', 'S', subsectionIndex: 13), Continuous(39)]
public class AirportMinimumAltitudes : Record424
{
    [Foreign(7, 12)]
    public Airport Airport { get; set; }

    [Type(21, 22)]
    [ForeignExcept<Airport, OmnidirectionalStation, NondirectionalBeacon, EnrouteWaypoint>(7, 12)]
    [Foreign(14, 20)]
    public IIdentity Center { get; set; }

    [Character(23)]
    public char MultipleCode { get; set; }

    [Field(43, 53), Count<Sector, SectorConverter>(7)]
    public Sector[] Sectors { get; set; }

    [Character(120)]
    public CourseType CourseType { get; set; }
}
