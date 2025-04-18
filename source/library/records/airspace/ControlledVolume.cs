namespace Arinc424.Airspace;

using Arinc424.Processing;

using Terms;

/**<summary>
<c>Controlled Airspace</c> primary record sequence
</summary>
<remarks>Used by <see cref="ControlledSpace"/> like subsequence.</remarks>*/
[Pipeline<Sequence<ControlledVolume, BoundaryPoint>>]

[DebuggerDisplay($"{nameof(Class)} - {{{nameof(Class)},nq}}, {nameof(Type)} - {{{nameof(Type)}}}")]
public class ControlledVolume : Volume
{
    /// <inheritdoc cref="AirspaceType"/>
    [Character(9)]
    public AirspaceType Type { get; set; }

    /**<summary>
    <c>Controlled Airspace Center (ARSP CNTR)</c> field.
    </summary>
    <remarks>See section 5.214.</remarks>*/
    [Type(15, 16)]
    [Identifier(10, 14)]
    public IIdentity Center { get; set; }

    /// <inheritdoc cref="AirspaceClass"/>
    [Character(17)]
    public AirspaceClass Class { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='RNP']/*"/>
    [Field(79, 81), Performance]
    public float Performance { get; set; }
}
