using Arinc424.Attributes;
using Arinc424.Ports;

namespace Arinc424.Procedures;

#pragma warning disable CS8618

/// <summary>
/// <c>Airport SID</c> primary record.
/// </summary>
/// <remarks>See section 4.1.9.1.</remarks>

[Record('P', 'D', subsectionIndex: 13)]
public class AirportDeparture : Departure
{
    [Foreign(7, 12)]
    public Airport Airport { get; set; }
}
