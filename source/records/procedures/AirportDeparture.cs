using Arinc424.Ports;

namespace Arinc424.Procedures;

/// <summary>
/// <c>Airport SID</c> primary record.
/// </summary>
/// <remarks>See section 4.1.9.1.</remarks>

[Section('P', 'D', subsectionIndex: 13)]
[DebuggerDisplay($"{{{nameof(Identifier)}}}, {nameof(Airport)} - {{{nameof(Airport)}}}")]
public class AirportDeparture : Departure
{
    [Foreign(7, 12)]
    public Airport Airport { get; set; }
}
