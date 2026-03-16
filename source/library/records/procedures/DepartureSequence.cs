namespace Arinc424.Procedures;

using Processing;

/**<summary>
<c>Airport</c> and <c>Heliport SID</c> primary record sequence.
</summary>
<remarks>Used by <see cref="Departure"/> like subsequence.</remarks>*/
[Pipe<Sequence<DepartureSequence, DepartureLeg>>]
public class DepartureSequence : ProcedureSequence<DepartureLeg>
{
    /// <inheritdoc cref="Terms.DepartureTypes"/>
    [Character(20)]
    public Terms.DepartureTypes Types { get; set; }
}
