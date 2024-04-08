using Arinc424.Attributes;

namespace Arinc424.Ports;

/// <summary>
/// <c>Airport SBAS Path Point</c> primary record.
/// </summary>
/// <remarks>See section 4.1.28.1.</remarks>
[Record('P', 'P', subsectionIndex: 13)]
[Obsolete("placeholder")]
public class AirportSatelliteAugmentPoint : Record424
{

}
