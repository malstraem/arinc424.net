using Arinc424.Ports;

namespace Arinc424.Comms;

/// <summary>
/// <c>Airport Communications</c> primary record.
/// </summary>
/// <remarks>See section 4.1.14.1.</remarks>
[Section('P', 'V', subsectionIndex: 13)]
[DebuggerDisplay($"{nameof(Class)} - {{{nameof(Class)}}}, {nameof(Airport)} - {{{nameof(Airport)}}}")]
public class AirportCommunications : Communications<PortTransmitter>
{
    [Foreign(7, 12)]
    public Airport Airport { get; set; }
}
