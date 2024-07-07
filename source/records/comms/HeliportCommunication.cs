using Arinc424.Ports;

namespace Arinc424.Comms;

/// <summary>
/// <c>Heliport Communications</c> primary record sequence.
/// </summary>
/// <remarks>See section 4.2.5.1.</remarks>
[Section('H', 'V', subsectionIndex: 13), Icao(11, 12)]
public class HeliportCommunication : Communication<PortTransmitter>, IIcao
{
    [Identifier(7, 10)]
    public Heliport Heliport { get; set; }

    [Field(11, 12)]
    public string IcaoCode { get; set; }
}
