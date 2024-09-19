using Arinc424.Processing;
using Arinc424.Tables;

namespace Arinc424.Airspace;

/// <summary>
/// <c>FIR/UIR</c> primary record sequence.
/// </summary>
/// <remarks>See section 4.1.17.1.</remarks>
[Identifier(7, 10), Sequenced(16, 19), Continuous(20)]
[Wrap<FlightRegion, RegionVolume, IdentifierTrigger<RegionVolume>>]
[DebuggerDisplay($"{{{nameof(Identifier)},nq}}, {{{nameof(Name)},nq}}")]
public class RegionVolume : Record424<RegionPoint>, IIdentity, INamed
{
    [Identifier(96, 97)]
    public CruiseTable? CruiseTable { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='FIR']/*"/>
    [Field(7, 10)]
    public string Identifier { get; set; }

    /// <summary>
    /// <c>FIR/UIR Address (ADDRESS)</c> field.
    /// </summary>
    /// <remarks>See section 5.151.</remarks>
    [Field(11, 14)]
    public string Address { get; set; }

    /// <inheritdoc cref="Terms.RegionType"/>
    [Character(15)]
    public Terms.RegionType Type { get; set; }

    /// <inheritdoc cref="Terms.SpeedReportUnit"/>
    [Character(29)]
    public Terms.SpeedReportUnit SpeedReportUnit { get; set; }

    /// <inheritdoc cref="Terms.AltitudeReportUnit"/>
    [Character(30)]
    public Terms.AltitudeReportUnit AltitudeReportUnit { get; set; }

    /// <summary>
    /// <c>FIR/UIR Entry Report (ENTRY)</c> character.
    /// </summary>
    /// <remarks>See section 5.124.</remarks>
    [Character(31)]
    public Bool IsEntryReport { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Limit']/*"/>
    [Field(81, 85)]
    public Altitude Up { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Limit']/*"/>
    [Field(86, 90)]
    public Altitude? UpperRegionLow { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Limit']/*"/>
    [Field(91, 95)]
    public Altitude? UpperRegionUp { get; set; }

    /// <summary>
    /// <c>FIR/UIR Name</c> field.
    /// </summary>
    /// <remarks>See section 5.125.</remarks>
    [Field(99, 123)]
    public string? Name { get; set; }
}
