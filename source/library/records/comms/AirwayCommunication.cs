namespace Arinc424.Comms;

using Processing;

/**<summary>
<c>Enroute Communications</c> primary record sequence.
</summary>
<remarks>See section 4.1.23.1.</remarks>*/
[Section('E', 'V'), ContinuousAttribute(56)]

[Pipeline<Sequence<AirwayCommunication, AirwayTransmitter>>(Start = Supplement.V19)]
[Pipeline<CommWrapBeforeV19<AirwayCommunication, AirwayTransmitter>>(End = Supplement.V19)]
public class AirwayCommunication : Communication<AirwayTransmitter>
{
    /// <summary><c>FIR/RDO Identifier (FIR/RDO)</c> field.</summary>
    /// <remarks>See section 5.190.</remarks>
    [Field(7, 10)]
    public string Identifier { get; set; }

    /// <summary><c>FIR/UIR Address (ADDRESS)</c> field.</summary>
    /// <remarks>See section 5.151.</remarks>
    [Field(11, 14)]
    public string? Address { get; set; }

    /// <inheritdoc cref="Airspace.Terms.RegionType"/>
    [Character(15)]
    public Airspace.Terms.RegionType Type { get; set; }
}
