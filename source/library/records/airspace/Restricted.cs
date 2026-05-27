namespace Arinc424.Airspace;

using Processing;

/**<summary>
<c>Restrictive Airspace</c> primary record sequence.
</summary>
<remarks>Used by <see cref="RestrictedSpace"/> like subsequence.</remarks>*/
[Pipe<Sequence<Restricted, BoundaryPoint>>]

[DebuggerDisplay($"{{{nameof(Type)},nq}}")]
public class Restricted : Volume
{
    /// <inheritdoc cref="Terms.RestrictedType"/>
    [Character(9)]
    public Terms.RestrictedType Type { get; set; }
}
