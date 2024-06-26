using Arinc424.Procedures;

namespace Arinc424.Ports;

/// <summary>
/// <c>Airport TAA</c> primary record.
/// </summary>
/// <remarks>See section 4.1.31.1.</remarks>
[Section('P', 'K', subsectionIndex: 13)]
public class AirportArrivalAltitude : ArrivalAltitude
{
    [Foreign(7, 12)]
    public Airport Airport { get; set; }

    [Foreign(7, 12), Foreign(14, 19), Foreign(11, 12)]
    public AirportApproach Approach { get; set; }
}
