namespace Arinc424.Airspace;

using Processing;

/**<summary>
Multiple <c>Controlled Airspace</c> primary record sequences.
</summary>
<remarks>See section 4.1.25.1.</remarks>*/
[Section('U', 'C'), Pipeline<ControlledConcatenate>]

[DebuggerDisplay($"{{{nameof(Icao)},nq}}, {{{nameof(Name)},nq}}")]
public class ControlledSpace : Space<ControlledVolume>;

/**<summary>
Multiple <c>Restrictive Airspace</c> primary record sequences.
</summary>
<remarks>See section 4.1.18.1.</remarks>*/
[Section('U', 'R'), Pipeline<RestrictiveWrap>]

[DebuggerDisplay($"{{{nameof(Icao)},nq}}, {{{nameof(Identifier)},nq}}")]
public class RestrictiveSpace : Space<RestrictiveVolume>, IIdentity
{
    /**<summary>
    <c>Restrictive Airspace Designation</c> field.
    </summary>
    <remarks>See section 5.129.</remarks>*/
    [Field(10, 19)]
    public string Identifier { get; set; }
}
