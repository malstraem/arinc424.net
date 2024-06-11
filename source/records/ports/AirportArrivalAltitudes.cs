using Arinc424.Navigation;
using Arinc424.Waypoints;

namespace Arinc424.Ports;

using Terms;

#pragma warning disable CS8618

/// <summary>
/// <c>Airport TAA</c> primary record.
/// </summary>
/// <remarks>See section 4.1.31.1.</remarks>
[Section('P', 'K', subsectionIndex: 13), Continuous(30)]
public class AirportArrivalAltitudes : Record424, IIcao
{
    [Foreign(7, 12)]
    public Airport Airport { get; set; }

    [Field(11, 12)]
    public string IcaoCode { get; set; }

    [Field(14, 19)]
    [Obsolete("todo: post process SID/STAR/Approach sequences to one entity to be able for linking")]
    public string Approach { get; set; }

    [Type(27, 28)]
    [ForeignExcept<EnrouteWaypoint, Omnidirectional, Nondirectional>(7, 12), Foreign(20, 26)]
    public Geo Fix { get; set; }

    /// <inheritdoc cref="Terms.FixPosition"/>
    [Character(29)]
    public FixPosition FixPosition { get; set; }

    [Field(33, 46), Count(6)]
    [Decode<ArrivalSectorConverter, ArrivalSector>]
    public ArrivalSector[] Sectors { get; set; }
}
