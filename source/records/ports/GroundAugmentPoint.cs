using Arinc424.Attributes;

namespace Arinc424.Ports;

/// <summary>
/// <c>GBAS Path Point</c> primary record.
/// </summary>
/// <remarks>See section 4.1.35.1.</remarks>
[Record('P', 'Q', subsectionIndex: 13)]
[Obsolete("placeholder")]
public class GroundAugmentPoint : Record424
{

}