namespace Arinc424.Comms;

/**<summary>
  Fields of <c>Enroute Communications</c>.
</summary>
<remarks>Used by <see cref="AirwayCommunication"/> like subsequence.</remarks>*/
[DebuggerDisplay($"{{{nameof(Narrative)},nq}}, {nameof(Type)} - {{{nameof(Type)}}}")]
public class AirwayTransmitter : Transmitter
{
    /**<summary>
      <c>Sectorization Narrative</c> field.
    </summary>
    <remarks>See section 5.186.
      <c>Remote Name</c> field before supplement 19, see section 5.189.
    </remarks>*/
    [Field(19, 43), Field(68, 92, Start = Supplement.V19)]
    public string? Narrative { get; set; }

    /// <inheritdoc cref="Terms.AirwayCommUsages"/>
    [Field(57, 59), Field(112, 114, Start = Supplement.V19)]
    public Terms.AirwayCommUsages Usages { get; set; }
}
