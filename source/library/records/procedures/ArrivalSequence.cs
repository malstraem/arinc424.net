using Arinc424.Processing;

namespace Arinc424.Procedures;

/// <summary>
/// <c>Airport and Heliport STAR</c> primary record sequence.
/// </summary>
/// <remarks>See section 4.1.9.1 and 4.2.3.1.</remarks>
[Pipeline<Sequence<ArrivalSequence, ArrivalPoint>>]
public class ArrivalSequence : ProcedureSequence<ArrivalPoint>
{
    /// <inheritdoc cref="Terms.ArrivalType"/>
    [Character(20)]
    public Terms.ArrivalType Type { get; set; }
}
