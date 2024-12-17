using Arinc424.Processing;
using Arinc424.Tables;

namespace Arinc424.Airspace;

/// <summary>
/// <c>FIR/UIR</c> primary record sequence.
/// </summary>
/// <remarks>See section 4.1.17.1.</remarks>
[Continuous(20), Pipeline<Sequence<RegionVolume, RegionPoint>>]

[DebuggerDisplay($"{{{nameof(Type)},nq}}")]
public class RegionVolume : Record424<RegionPoint>
{
    [Identifier(96, 97)]
    public CruiseTable? CruiseTable { get; set; }

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
    public Altitude UpperRegionLow { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Limit']/*"/>
    [Field(91, 95)]
    public Altitude UpperRegionUp { get; set; }
}
