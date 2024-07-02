namespace Arinc424.Ports;

/// <summary>
/// <c>Airport MSA</c> primary record.
/// </summary>
/// <remarks>See section 4.1.20.1.</remarks>
[Section('P', 'S', subsectionIndex: 13), Continuous(39)]
public class AirportMinimumAltitude : MinimumAltitude
{
    [Foreign(7, 12)]

    [Identifier(7, 10), Icao(11, 12)]
    public Airport Airport { get; set; }
}
