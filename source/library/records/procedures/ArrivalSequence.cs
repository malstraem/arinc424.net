using Arinc424.Processing;

namespace Arinc424.Procedures;

[Process<Arrival, ArrivalSequence,
    ProcedureConcatenater<Arrival, ArrivalSequence, ArrivalPoint>>] // any more elegant way?
public class ArrivalSequence : ProcedureSequence<ArrivalPoint>
{
    /// <inheritdoc cref="Terms.ArrivalType"/>
    [Character(20)]
    public Terms.ArrivalType Type { get; set; }
}
