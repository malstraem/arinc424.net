using System.Diagnostics;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Converters;
using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Records;

#pragma warning disable CS8618

/// <summary>
/// <c>FIR/UIR</c> primary record.
/// </summary>
/// <remarks>See section 4.1.17.1.</remarks>
[Record('U', 'F'), Continuous(20), Sequenced(16, 19)]
[DebuggerDisplay($"{{{nameof(Identifier)}}}, {{{nameof(Name)}}}")]
public class FlightInfoRegion : Record424<InfoRegionPoint>, IIdentity
{
    /// <include file='Comments.xml' path="doc/member[@name='FIR']/*"/>
    [Field(7, 10)]
    public string Identifier { get; init; }

    /// <summary>
    /// <c>FIR/UIR Address (ADDRESS)</c> field.
    /// </summary>
    /// <remarks>See section 5.151.</remarks>
    [Field(11, 14)]
    public string Address { get; init; }

    /// <summary>
    /// <c>FIR/UIR Indicator (IND)</c> character.
    /// </summary>
    /// <remarks>See section 5.117.</remarks>
    [Character(15)]
    public char Indicator { get; init; }

    /// <inheritdoc cref="Terms.SpeedReportUnit"/>
    [Character(29), Transform<SpeedReportUnitConverter>]
    public SpeedReportUnit SpeedReportUnit { get; init; }

    /// <summary>
    /// <c>FIR/UIR ATC Reporting Units Altitude (RUA)</c> character.
    /// </summary>
    /// <remarks>See section 5.123.</remarks>
    [Character(30)]
    public char ReportAltitudeUnits { get; init; }

    /// <summary>
    /// <c>FIR/UIR Entry Report (ENTRY)</c> character.
    /// </summary>
    /// <remarks>See section 5.124.</remarks>
    [Character(31), Transform<BoolConverter>]
    public bool EntryReportRequired { get; init; }

    /// <include file='Comments.xml' path="doc/member[@name='Limit']/*"/>
    [Field(81, 85), Decode<AltitudeConverter>]
    public (int Altitude, AltitudeUnit Unit) Up { get; init; }

    /// <include file='Comments.xml' path="doc/member[@name='Limit']/*"/>
    [Field(86, 90), Decode<AltitudeConverter>]
    public (int Altitude, AltitudeUnit Unit)? UpperLow { get; init; }

    /// <include file='Comments.xml' path="doc/member[@name='Limit']/*"/>
    [Field(91, 95), Decode<AltitudeConverter>]
    public (int Altitude, AltitudeUnit Unit)? UpperUp { get; init; }

    [Foreign(96, 97)]
    public CruiseTable? CruiseTable { get; init; }

    /// <summary>
    /// <c>FIR/UIR Name</c> field.
    /// </summary>
    /// <remarks>See section 5.125.</remarks>
    [Field(99, 123)]
    public string Name { get; init; }
}
