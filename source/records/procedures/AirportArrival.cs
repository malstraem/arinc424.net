using System.Diagnostics;

using Arinc424.Attributes;
using Arinc424.Ports;

namespace Arinc424.Procedures;

#pragma warning disable CS8618

/// <summary>
/// <c>Airport STAR</c> primary record.
/// </summary>
/// <remarks>See section 4.1.9.1.</remarks>
[Section('P', 'E', subsectionIndex: 13)]
[DebuggerDisplay($"{{{nameof(Identifier)}}}, {nameof(Airport)} - {{{nameof(Airport)}}}")]
public class AirportArrival : Arrival
{
    [Foreign(7, 12)]
    public Airport Airport { get; set; }
}
