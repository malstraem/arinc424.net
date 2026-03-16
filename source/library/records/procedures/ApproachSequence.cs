namespace Arinc424.Procedures;

using Processing;

/**<summary>
<c>Airport</c> and <c>Heliport Approach</c> primary record sequence.
</summary>
<remarks>Used by <see cref="Approach"/> like subsequence.</remarks>*/
[Pipe<Sequence<ApproachSequence, ApproachLeg>>]
public class ApproachSequence : ProcedureSequence<ApproachLeg>
{
    /// <inheritdoc cref="Terms.ApproachTypes"/>
    [Character(20)]
    public Terms.ApproachTypes Types { get; set; }
}
