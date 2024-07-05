using Arinc424.Procedures;

namespace Arinc424.Ports;

/// <summary>
/// <c>Airport TAA</c> primary record.
/// </summary>
/// <remarks>See section 4.1.31.1.</remarks>
[Section('P', 'K', subsectionIndex: 13)]
public class AirportArrivalAltitude : ArrivalAltitude
{
    [Identifier(7, 10)]
    public Airport Airport { get; set; }

    [Identifier(14, 19)]
    public AirportApproach Approach { get; set; }
}
