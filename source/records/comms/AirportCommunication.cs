using Arinc424.Ports;

namespace Arinc424.Comms;

/// <summary>
/// <c>Airport Communications</c> primary record sequence.
/// </summary>
/// <remarks>See section 4.1.14.1.</remarks>
[Section('P', 'V', subsectionIndex: 13), Icao(11, 12)]
[DebuggerDisplay($"{{{nameof(Class)}}}, {nameof(Airport)} - {{{nameof(Airport)}}}")]
public class AirportCommunication : Communication<PortTransmitter>, IIcao
{
    [Identifier(7, 10)]
    public Airport Airport { get; set; }

    [Field(11, 12)]
    public string IcaoCode { get; set; }
}
