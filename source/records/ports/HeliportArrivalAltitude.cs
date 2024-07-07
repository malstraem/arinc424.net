using Arinc424.Procedures;

namespace Arinc424.Ports;

/// <summary>
/// <c>Heliport TAA</c> primary record.
/// </summary>
/// <remarks>See section 4.2.6.1.</remarks>
[Section('H', 'K', subsectionIndex: 13)]
public class HeliportArrivalAltitude : ArrivalAltitude
{
    [Identifier(7, 10)]
    public Heliport Heliport { get; set; }

    [Identifier(14, 19)]
    public HeliportApproach Approach { get; set; }
}
