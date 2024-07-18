using Arinc424.Ports;
using Arinc424.Processing;

namespace Arinc424.Comms;

/// <summary>
/// <c>Airport and Heliport Communications</c> primary record sequence.
/// </summary>
/// <remarks>See section 4.1.14.1 and 4.2.5.1.</remarks>
[Section('P', 'V', subsectionIndex: 13)]
[Section('H', 'V', subsectionIndex: 13)]
[Icao(11, 12), Continuous(26)]
[Process<PortCommunication, PortCommunication, PortCommsConcatanater>(end: Supplement.V18)]
[DebuggerDisplay($"{{{nameof(Class)}}}, {nameof(Port)} - {{{nameof(Port)}}}")]
public class PortCommunication : Communication<PortTransmitter>
{
    [Identifier(7, 10)]
    [Possible<Airport, Heliport>]
    public Port Port { get; set; }
}
