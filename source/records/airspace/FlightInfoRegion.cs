using Arinc424.Tables;

namespace Arinc424.Airspace;

#pragma warning disable CS8618

/// <summary>
/// <c>FIR/UIR</c> primary record.
/// </summary>
/// <remarks>See section 4.1.17.1.</remarks>
[Section('U', 'F'), Continuous(20), Sequenced(16, 19)]
[DebuggerDisplay($"{{{nameof(Identifier)}}}, {{{nameof(Name)}}}")]
public class FlightInfoRegion : Record424<FlightRegionPoint>, IIdentity, IIcao, INamed
{
    [Foreign(96, 97)]
    public CruiseTable? CruiseTable { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='FIR']/*"/>
    [Field(7, 10), Primary]
    public string Identifier { get; set; }

    [Field(7, 8)]
    public string IcaoCode { get; set; }

    /// <summary>
    /// <c>FIR/UIR Address (ADDRESS)</c> field.
    /// </summary>
    /// <remarks>See section 5.151.</remarks>
    [Field(11, 14)]
    public string Address { get; set; }

    /// <summary>
    /// <c>FIR/UIR Indicator (IND)</c> character.
    /// </summary>
    /// <remarks>See section 5.117.</remarks>
    [Character(15), Obsolete("todo")]
    public char Indicator { get; set; }

    /// <inheritdoc cref="Terms.SpeedReportUnit"/>
    [Character(29), Transform<SpeedReportUnitConverter>]
    public Terms.SpeedReportUnit SpeedReportUnit { get; set; }

    /// <inheritdoc cref="Terms.AltitudeReportUnit"/>
    [Character(30), Transform<AltitudeReportUnitConverter>]
    public Terms.AltitudeReportUnit AltitudeReportUnit { get; set; }

    /// <summary>
    /// <c>FIR/UIR Entry Report (ENTRY)</c> character.
    /// </summary>
    /// <remarks>See section 5.124.</remarks>
    [Character(31), Transform<BoolConverter>]
    public Bool IsEntryReport { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Limit']/*"/>
    [Field(81, 85), Decode<AltitudeConverter>]
    public Altitude Up { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Limit']/*"/>
    [Field(86, 90), Decode<AltitudeConverter>]
    public Altitude? UpperLow { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Limit']/*"/>
    [Field(91, 95), Decode<AltitudeConverter>]
    public Altitude? UpperUp { get; set; }

    /// <summary>
    /// <c>FIR/UIR Name</c> field.
    /// </summary>
    /// <remarks>See section 5.125.</remarks>
    [Field(99, 123)]
    public string? Name { get; set; }
}
