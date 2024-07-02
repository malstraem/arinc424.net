using Arinc424.Ports;

namespace Arinc424.Comms;

/// <summary>
/// <c>Heliport Communications</c> primary record sequence.
/// </summary>
/// <remarks>See section 4.2.5.1.</remarks>
[Section('H', 'V', subsectionIndex: 13)]
public class HeliportCommunication : Communication<PortTransmitter>
{
    [Foreign(7, 12)]

    [Identifier(7, 10), Icao(11, 12)]
    public Heliport Heliport { get; set; }
}
