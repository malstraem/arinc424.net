using System.Diagnostics;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Terms.Subsequences;

namespace Arinc.Spec424.Records;

/// <summary>
/// <c>Controlled Airspace</c> primary record.
/// </summary>
/// <remarks>See paragraph 4.1.25.1.</remarks>
[Record('U', 'C'), Continuation(25), Sequenced(21, 24)]
[DebuggerDisplay("Area - {AreaCode}, Name - {Name}")]
public class ControlledAirspace : SequencedRecord424<BoundaryPoint>
{
    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.14.</remarks>
    [Field(7, 8)]
    public required string IcaoCode { get; init; }

    /// <summary>
    /// <c>Controlled Airspace Type (ARSP TYPE)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.213.</remarks>
    [Character(9)]
    public required char Type { get; init; }

    /// <summary>
    /// <c>Controlled Airspace Center (ARSP CNTR)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.214.</remarks>
    [Field(10, 14)]
    public required string Center { get; init; }

    /// <summary>
    /// <c>Section Code (SEC CODE)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.4.</remarks>
    [Character(15)]
    public required char SectionLink { get; init; }

    /// <summary>
    /// <c>Subsection Code (SUB CODE)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.5.</remarks>
    [Character(16)]
    public required char SubsectionLink { get; init; }

    /// <summary>
    /// <c>Controlled Airspace Classification (ARSP CLASS)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.215.</remarks>
    [Character(17)]
    public required char Classification { get; init; }

    /// <summary>
    /// <c>Multiple Code (MULTI CD)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.130.</remarks>
    [Character(20)]
    public required char MultipleCode { get; init; }

    /// <summary>
    /// <c>Level (LEVEL)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.19.</remarks>
    [Character(26)]
    public required char Level { get; init; }

    /// <summary>
    /// <c>Time Code (TIME CD)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.131.</remarks>
    [Character(27)]
    public required char TimeCode { get; init; }

    /// <summary>
    /// <c>NOTAM</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.132.</remarks>
    [Character(28)]
    public required char Notam { get; init; }

    /// <summary>
    /// <c>Required Navigation Performance (RNP)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.211.</remarks>
    [Field(79, 81)]
    public required string? RequiredNavigationPerformance { get; init; }

    /// <summary>
    /// <c>Lower Limit</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.121.</remarks>
    [Field(82, 86)]
    public required string LowerLimit { get; init; }

    /// <summary>
    /// <c>Unit Indicator (UNIT IND)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.133.</remarks>
    [Character(87)]
    public required char LowerLimitUnit { get; init; }

    /// <summary>
    /// <c>UpperLimit</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.121.</remarks>
    [Field(88, 92)]
    public required string UpperLimit { get; init; }

    /// <summary>
    /// <c>Unit Indicator (UNIT IND)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.133.</remarks>
    [Character(93)]
    public required char UpperLimitUnit { get; init; }

    /// <summary>
    /// <c>Controlled Airspace Name (ARSP NAME)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.216.</remarks>
    [Field(94, 123)]
    public required string Name { get; init; }
}
