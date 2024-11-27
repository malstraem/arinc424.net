using Arinc424.Processing;

namespace Arinc424.Procedures;

[Pipeline<Sequence<DepartureSequence, DeparturePoint>>]
public class DepartureSequence : ProcedureSequence<DeparturePoint>
{
    /// <inheritdoc cref="Terms.DepartureType"/>
    [Character(20)]
    public Terms.DepartureType Type { get; set; }
}
