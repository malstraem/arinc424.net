using Arinc424.Airspace.Terms;
using Arinc424.Processing;

namespace Arinc424.Comms;

/// <summary>
/// <c>Enroute Communications</c> primary record sequence.
/// </summary>
/// <remarks>See section 4.1.23.1.</remarks>
[Section('E', 'V'), Continuous(56)]

[Pipeline<Sequence<AirwayCommunication, AirwayTransmitter>>(start: Supplement.V19)]
[Pipeline<CommWrapBeforeV19<AirwayCommunication, AirwayTransmitter>>(end: Supplement.V19)]
public class AirwayCommunication : Communication<AirwayTransmitter>
{
    /// <summary>
    /// <c>FIR/RDO Identifier (FIR/RDO)</c> field.
    /// </summary>
    /// <remarks>See section 5.190.</remarks>
    [Field(7, 10)]
    public string Identifier { get; set; }

    /// <summary>
    /// <c>FIR/UIR Address (ADDRESS)</c> field.
    /// </summary>
    /// <remarks>See section 5.151.</remarks>
    [Field(11, 14)]
    public string? Address { get; set; }

    /// <inheritdoc cref="RegionType"/>
    [Character(15)]
    public RegionType Type { get; set; }
}
