namespace Arinc424.Ports;

/// <summary>
/// <c>Airport SBAS Path Point</c> primary record.
/// </summary>
/// <remarks>See section 4.1.28.1.</remarks>
[Section('P', 'P', subsectionIndex: 13), Continuous(27)]
public class AirportSatellitePoint : SatellitePoint
{
    [Foreign(7, 12)]
    public Airport Airport { get; set; }

    [Foreign(7, 12), Foreign(20, 24), Foreign(11, 12)]
    public Runway Runway { get; set; }
}