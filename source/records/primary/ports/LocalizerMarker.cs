using Arinc424.Attributes;

namespace Arinc424.Ports;

/// <summary>
/// <c> Airport and Heliport Localizer Marker</c> primary record.
/// </summary>
/// <remarks>See section 4.1.13.1.</remarks>
[Record('P', 'M', subsectionIndex: 13)]
[Obsolete("placeholder")]
public class LocalizerMarker : Record424
{

}
