using Arinc424.Attributes;

namespace Arinc424.Procedures;

/// <summary>
/// <c>Heliport SID</c> primary record.
/// </summary>
/// <remarks>See section 4.2.3.1.</remarks>
[Record('H', 'D', subsectionIndex: 13)]
[Obsolete("placeholder")]
public class HeliportDeparture : Departure
{

}
