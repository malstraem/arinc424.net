namespace Arinc424.Airspace;

using Processing;

/**<summary>
<c>Restrictive Airspace</c> primary record sequence.
</summary>
<remarks>Used by <see cref="RestrictiveSpace"/> like subsequence.</remarks>*/
[Pipeline<Sequence<RestrictiveVolume, BoundaryPoint>>]

[DebuggerDisplay($"{{{nameof(Type)},nq}}")]
public class RestrictiveVolume : Volume
{
    /// <inheritdoc cref="Terms.RestrictiveType"/>
    [Character(9)]
    public Terms.RestrictiveType Type { get; set; }
}
