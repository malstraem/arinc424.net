using Arinc424.Processing;

namespace Arinc424.Procedures;

/// <summary>
/// <c>Airport and Heliport SID</c> primary record sequence.
/// </summary>
/// <remarks>See section 4.1.9.1 and 4.2.3.1.</remarks>
[Pipeline<Sequence<DepartureSequence, DeparturePoint>>]
public class DepartureSequence : ProcedureSequence<DeparturePoint>
{
    /// <inheritdoc cref="Terms.DepartureType"/>
    [Character(20)]
    public Terms.DepartureType Type { get; set; }
}
