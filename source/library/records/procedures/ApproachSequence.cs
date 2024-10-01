using Arinc424.Processing;

namespace Arinc424.Procedures;

[Pipeline<IdentityWrap<Approach, ApproachSequence>, ApproachSequence>]
public class ApproachSequence : ProcedureSequence<ApproachPoint>
{
    /// <inheritdoc cref="Terms.ApproachType"/>
    [Character(20)]
    public Terms.ApproachType Type { get; set; }
}
