using Arinc424.Procedures;

namespace Arinc424.Ports;

/// <summary>
/// <c>Heliport TAA</c> primary record.
/// </summary>
/// <remarks>See section 4.2.6.1.</remarks>
[Section('H', 'K', subsectionIndex: 13)]
public class HeliportArrivalAltitude : ArrivalAltitude
{
    [Foreign(7, 12)]

    [Identifier(7, 10), Icao(11, 12)]
    public Heliport Heliport { get; set; }

    [Foreign(14, 19)]

    [Identifier(14, 19), Icao(11, 12), Port(7, 10)]
    public HeliportApproach Approach { get; set; }
}
