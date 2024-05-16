using Arinc424.Ports;

namespace Arinc424.Comms;

/// <summary>
/// <c>Heliport Communications</c> primary record.
/// </summary>
/// <remarks>See section 4.2.5.1.</remarks>
[Section('H', 'V', subsectionIndex: 13)]
public class HeliportCommunications : Communications<PortTransmitter>
{
    [Foreign(7, 12)]
    public Heliport Heliport { get; set; }
}
