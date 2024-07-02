using Arinc424.Airspace;

namespace Arinc424.Comms;

/// <summary>
/// <c>Enroute Communications</c> primary record sequence.
/// </summary>
/// <remarks>See section 4.1.23.1.</remarks>
[Section('E', 'V')]
public class AirwayCommunication : Communication<AirwayTransmitter>
{
    [Foreign(7, 10)]
    [Identifier(7, 10)]
    public FlightRegion FlightRegion { get; set; }

    /// <summary>
    /// <c>FIR/UIR Address (ADDRESS)</c> field.
    /// </summary>
    /// <remarks>See section 5.151.</remarks>
    [Field(11, 14), Obsolete("todo")]
    public string Address { get; set; }

    [Character(15), Obsolete("todo")]
    public char Indicator { get; set; }
}
