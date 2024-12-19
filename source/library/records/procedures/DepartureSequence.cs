using Arinc424.Processing;

namespace Arinc424.Procedures;

/// <summary>
/// <c>Airport and Heliport SID</c> primary record sequence.
/// </summary>
/// <remarks>Used by <see cref="Departure"/> like subsequence.</remarks>
[Pipeline<Sequence<DepartureSequence, DeparturePoint>>]
public class DepartureSequence : ProcedureSequence<DeparturePoint>
{
    /// <inheritdoc cref="Terms.DepartureType"/>
    [Character(20)]
    public Terms.DepartureType Type { get; set; }
}
