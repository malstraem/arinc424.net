using Arinc424.Processing;

namespace Arinc424.Procedures;

/// <summary>
/// <c>Airport and Heliport Approach</c> primary record sequence.
/// </summary>
/// <remarks>See section 4.1.9.1.</remarks>
[Process<Approach, ApproachSequence,
    ProcedureConcatenater<Approach, ApproachSequence, ApproachPoint>>]
public class ApproachSequence : ProcedureSequence<ApproachPoint>
{
    /// <inheritdoc cref="Terms.ApproachType"/>
    [Character(20)]
    public Terms.ApproachType Type { get; set; }
}
