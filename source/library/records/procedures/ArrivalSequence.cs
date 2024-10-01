using Arinc424.Processing;

namespace Arinc424.Procedures;

[Pipeline<IdentityWrap<Arrival, ArrivalSequence>, ArrivalSequence>]
public class ArrivalSequence : ProcedureSequence<ArrivalPoint>
{
    /// <inheritdoc cref="Terms.ArrivalType"/>
    [Character(20)]
    public Terms.ArrivalType Type { get; set; }
}
