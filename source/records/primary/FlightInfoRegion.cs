using System.Diagnostics;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Terms.Subsequences;

namespace Arinc.Spec424.Records;

/// <summary>
/// <c>FIR/UIR</c> primary record.
/// </summary>
/// <remarks>See paragraph 4.1.17.1.</remarks>
[Record('U', 'F'), Continuation(20), Sequenced(16, 19)]
[DebuggerDisplay("Area - {AreaCode}, Identifier - {Identifier}, Name - {Name}")]
public record FlightInfoRegion : SequencedRecord424<BoundaryPoint>
{
    /// <summary>
    /// <c>FIR/UIR Identifier (FIR/UIR IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.116.</remarks>
    [Field(7, 10)]
    public required string Identifier { get; init; }

    /// <summary>
    /// <c>FIR/UIR Address (ADDRESS)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.151.</remarks>
    [Field(11, 14)]
    public required string Address { get; init; }

    /// <summary>
    /// <c>FIR/UIR Indicator (IND)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.117.</remarks>
    [Character(15)]
    public required char Indicator { get; init; }

    /// <summary>
    /// <c>FIR Identifier (FIR IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.116.</remarks>
    [Field(21, 24)]
    public string? AdjacentIdentifier { get; init; }

    /// <summary>
    /// <c>UIR Identifier (UIR IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.116.</remarks>
    [Field(25, 28)]
    public string? AdjacentUirIdentifier { get; init; }

    /// <summary>
    /// <c>FIR/UIR ATC Reporting Units Speed (RUS)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.122.</remarks>
    [Character(29)]
    public required char ReportSpeedUnits { get; init; }

    /// <summary>
    /// <c>FIR/UIR ATC Reporting Units Altitude (RUA)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.123.</remarks>
    [Character(30)]
    public required char ReportAltitudeUnits { get; init; }

    /// <summary>
    /// <c>FIR/UIR Entry Report (ENTRY)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.124.</remarks>
    [Character(31)]
    public required char EntryReport { get; init; }

    /// <summary>
    /// <c>Upper Limit</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.121.</remarks>
    [Field(81, 85)]
    public required string UpperLimit { get; init; }

    /// <summary>
    /// <c>Lower Limit</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.121.</remarks>
    [Field(86, 90)]
    public string? UirLowerLimit { get; init; }

    /// <summary>
    /// <c>Upper Limit</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.121.</remarks>
    [Field(91, 95)]
    public string? UirUpperLimit { get; init; }

    /// <summary>
    /// <c>Cruise Table Identifier (CRSE TBL IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.134.</remarks>
    [Field(96, 97)]
    public string? CruiseTableIndicator { get; init; }

    /// <summary>
    /// <c>FIR/UIR Name</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.125.</remarks>
    [Field(99, 123)]
    public required string Name { get; init; }
}
