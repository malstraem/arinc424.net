using Arinc424.Ports;

namespace Arinc424.Comms;

/// <summary>
/// <c>Airport Communications</c> primary record sequence.
/// </summary>
/// <remarks>See section 4.1.14.1.</remarks>
[Section('P', 'V', subsectionIndex: 13)]
[DebuggerDisplay($"{{{nameof(Class)}}}, {nameof(Airport)} - {{{nameof(Airport)}}}")]
public class AirportCommunication : Communication<PortTransmitter>
{
    [Foreign(7, 12)]

    [Identifier(7, 10), Icao(11, 12)]
    public Airport Airport { get; set; }
}