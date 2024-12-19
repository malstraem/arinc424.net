using Arinc424.Processing;

namespace Arinc424.Airspace;

/// <summary>
/// Multiple <c>FIR/UIR</c> primary record sequences.
/// </summary>
/// <remarks>See section 4.1.17.1.</remarks>
[Section('U', 'F'), Identifier(7, 10)]

[Pipeline<IdentityWrap<FlightRegion, RegionVolume>>]

[DebuggerDisplay($"{{{nameof(Identifier)},nq}}, {{{nameof(Name)},nq}}")]
public class FlightRegion : Record424<RegionVolume>, IIdentity, INamed
{
    /// <include file='Comments.xml' path="doc/member[@name='FIR']/*"/>
    [Field(7, 10)]
    public string Identifier { get; set; }

    /// <summary>
    /// <c>FIR/UIR Address (ADDRESS)</c> field.
    /// </summary>
    /// <remarks>See section 5.151.</remarks>
    [Field(11, 14)]
    public string Address { get; set; }

    /// <summary>
    /// <c>FIR/UIR Name</c> field.
    /// </summary>
    /// <remarks>See section 5.125.</remarks>
    [Field(99, 123)]
    public string? Name { get; set; }
}
