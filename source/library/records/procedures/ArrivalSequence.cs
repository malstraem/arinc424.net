namespace Arinc424.Procedures;

using Processing;

/**<summary>
<c>Airport</c> and <c>Heliport STAR</c> primary record sequence.
</summary>
<remarks>Used by <see cref="Arrival"/> like subsequence.</remarks>*/
[Pipe<Sequence<ArrivalSequence, ArrivalLeg>>]
public class ArrivalSequence : ProcedureSequence<ArrivalLeg>
{
    /// <inheritdoc cref="Terms.ArrivalTypes"/>
    [Character(20)]
    public Terms.ArrivalTypes Types { get; set; }
}
