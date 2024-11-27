using Arinc424.Processing;

namespace Arinc424.Airspace;

[Section('U', 'R')]

[Pipeline<MultipleWrap<RestrictiveSpace, RestrictiveVolume>>]

[DebuggerDisplay($"{{{nameof(Icao)},nq}}, {{{nameof(Designation)},nq}}")]
public class RestrictiveSpace : Space<RestrictiveVolume>, INamed
{
    /// <summary>
    /// <c>Restrictive Airspace Designation</c> field.
    /// </summary>
    /// <remarks>See section 5.129.</remarks>
    [Field(10, 19)]
    public string Designation { get; set; }

    /// <summary>
    /// <c>Restrictive Airspace Name</c> field.
    /// </summary>
    /// <remarks>See section 5.126.</remarks>
    [Field(94, 123)]
    public string? Name { get; set; }
}
