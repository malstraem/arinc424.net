using Arinc424.Processing;

namespace Arinc424.Airspace;

[Section('U', 'R')]

[Pipeline<RestrictiveWrap>]

[DebuggerDisplay($"{{{nameof(Icao)},nq}}, {{{nameof(Identifier)},nq}}")]
public class RestrictiveSpace : Space<RestrictiveVolume>, IIdentity
{
    /// <summary>
    /// <c>Restrictive Airspace Designation</c> field.
    /// </summary>
    /// <remarks>See section 5.129.</remarks>
    [Field(10, 19)]
    public string Identifier { get; set; }
}
