using Arinc424.Procedures;

namespace Arinc424.Ports;

/// <summary>
/// <c>Airport SBAS Path Point</c> primary record.
/// </summary>
/// <remarks>See section 4.1.28.1.</remarks>
[Section('P', 'P', subsectionIndex: 13), Port(7, 10)]
public class AirportSatellitePoint : SatellitePoint
{
    [Identifier(7, 10)]
    public Airport Airport { get; set; }

    [Identifier(14, 19)]
    public AirportApproach Approach { get; set; }

    [Identifier(20, 24)]
    public Runway Runway { get; set; }
}
