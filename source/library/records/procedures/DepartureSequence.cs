namespace Arinc424.Procedures;

using Processing;

/**<summary>
<c>Airport</c> and <c>Heliport SID</c> primary record sequence.
</summary>
<remarks>Used by <see cref="Departure"/> like subsequence.</remarks>*/
[Pipe<Sequence<DepartureSequence, DeparturePoint>>]
public class DepartureSequence : ProcedureSequence<DeparturePoint>
{
    /// <inheritdoc cref="Terms.DepartureTypes"/>
    [Character(20)]
    public Terms.DepartureTypes Types { get; set; }
}
