using Arinc424.Processing;

namespace Arinc424.Procedures;

/// <summary>
/// <c>Airport and Heliport STAR</c> primary record sequence.
/// </summary>
/// <remarks>Used by <see cref="Arrival"/> like subsequence.</remarks>
[Pipeline<Sequence<ArrivalSequence, ArrivalPoint>>]
public class ArrivalSequence : ProcedureSequence<ArrivalPoint>
{
    /// <inheritdoc cref="Terms.ArrivalType"/>
    [Character(20)]
    public Terms.ArrivalType Type { get; set; }
}
