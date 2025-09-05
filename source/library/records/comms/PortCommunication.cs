namespace Arinc424.Comms;

using Processing;

/**<summary>
<c>Airport and Heliport Communications</c> primary record sequence.
</summary>
<remarks>See section 4.1.14.1 and 4.2.5.1.</remarks>*/
[Section('P', 'V', subInd: 13), Section('H', 'V', subInd: 13)]

[Port(7, 10), Icao(11, 12), Continuous(26)]

[Pipe<Sequence<PortCommunication, PortTransmitter>>(Start = Supplement.V19)]
[Pipe<CommWrapBeforeV19<PortCommunication, PortTransmitter>>(End = Supplement.V19)]

[DebuggerDisplay($"{{{nameof(Class)}}}, {nameof(Port)} - {{{nameof(Port)}}}")]
public class PortCommunication : Communication<PortTransmitter>
{
    public Ground.Port Port { get; set; }
}
