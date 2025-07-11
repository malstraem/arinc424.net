namespace Arinc424.Airspace;

using Processing;

/**<summary>
<c>Controlled Airspace</c> primary record sequence.
</summary>
<remarks>Used by <see cref="ControlledSpace"/> like subsequence.</remarks>*/
[Pipeline<Sequence<ControlledVolume, BoundaryPoint>>]

[DebuggerDisplay($"{nameof(Class)} - {{{nameof(Class)},nq}}, {nameof(Type)} - {{{nameof(Type)}}}")]
public class ControlledVolume : Volume
{
    /// <inheritdoc cref="Terms.AirspaceType"/>
    [Character(9)]
    public Terms.AirspaceType Type { get; set; }

    /**<summary>
    <c>Controlled Airspace Center (ARSP CNTR)</c> field.
    </summary>
    <remarks>See section 5.214.</remarks>*/
    [Known(10, 14), Type(15, 16)]
    public IIdentity Center { get; set; }

    /// <inheritdoc cref="Terms.AirspaceClass"/>
    [Character(17)]
    public Terms.AirspaceClass Class { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='RNP']/*"/>
    [Field(79, 81), Performance]
    public float Performance { get; set; }
}
