namespace Arinc424.Procedures;

using Processing;

/**<summary>
<c>Airport and Heliport Approach</c> primary record sequence.
</summary>
<remarks>Used by <see cref="Approach"/> like subsequence.</remarks>*/
[Pipeline<Sequence<ApproachSequence, ApproachPoint>>]
public class ApproachSequence : ProcedureSequence<ApproachPoint>
{
    /// <inheritdoc cref="Terms.ApproachType"/>
    [Character(20)]
    public Terms.ApproachType Type { get; set; }
}
