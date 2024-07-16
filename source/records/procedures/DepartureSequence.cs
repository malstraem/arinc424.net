using Arinc424.Processing;

namespace Arinc424.Procedures;

/// <summary>
/// <c>Airport SID</c> primary record sequence.
/// </summary>
/// <remarks>See section 4.1.9.1.</remarks>
[Process<Departure, DepartureSequence,
    ProcedureConcatenater<Departure, DepartureSequence, DeparturePoint>>]
public class DepartureSequence : ProcedureSequence<DeparturePoint>
{
    /// <inheritdoc cref="Terms.DepartureType"/>
    [Character(20)]
    public Terms.DepartureType Type { get; set; }
}
