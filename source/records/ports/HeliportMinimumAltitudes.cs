using Arinc424.Attributes;

namespace Arinc424.Ports;

/// <summary>
/// <c>Heliport MSA</c> primary record.
/// </summary>
/// <remarks>See section 4.2.4.1.</remarks>
[Record('H', 'S', subsectionIndex: 13)]
[Obsolete("placeholder")]
public class HeliportMinimumAltitudes : Record424
{

}