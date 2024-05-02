using Arinc424.Airspace;
using Arinc424.Attributes;
using Arinc424.Comms;

namespace Arinc424.Routing;

/// <summary>
/// <c>Enroute Communications</c> primary record.
/// </summary>
/// <remarks>See section 4.1.8.1.</remarks>
[Section('E', 'V')]
public class AirwayCommunications : Communications<AirwayTransmitter>
{
    [Foreign(7, 10), Obsolete("todo")]
    public FlightInfoRegion FlightInfoRegion { get; set; }

    /// <summary>
    /// <c>FIR/UIR Address (ADDRESS)</c> field.
    /// </summary>
    /// <remarks>See section 5.151.</remarks>
    [Field(11, 14), Obsolete("todo")]
    public string Address { get; set; }

    [Character(15), Obsolete("todo")]
    public char Indicator { get; set; }
}
