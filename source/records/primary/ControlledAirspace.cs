using System.Diagnostics;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Records.Subsequences;

namespace Arinc.Spec424.Records;

#pragma warning disable CS8618

/// <summary>
/// <c>Controlled Airspace</c> primary record.
/// </summary>
/// <remarks>See paragraph 4.1.25.1.</remarks>
[Record('U', 'C'), Continious(25), Sequenced(21, 24)]
[DebuggerDisplay($"{{{nameof(AreaCode)}}}, {{{nameof(Name)}}}")]
public class ControlledAirspace : Record424<BoundaryPoint>, IIcao
{
    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.14.</remarks>
    [Field(7, 8)]
    public string IcaoCode { get; init; }

    /// <summary>
    /// <c>Controlled Airspace Type (ARSP TYPE)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.213.</remarks>
    [Character(9)]
    public char Type { get; init; }

    /// <summary>
    /// <c>Controlled Airspace Center (ARSP CNTR)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.214.</remarks>
    [Field(10, 14)]
    public string Center { get; init; }

    /// <summary>
    /// <c>Section Code (SEC CODE)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.4.</remarks>
    [Character(15)]
    public char SectionLink { get; init; }

    /// <summary>
    /// <c>Subsection Code (SUB CODE)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.5.</remarks>
    [Character(16)]
    public char SubsectionLink { get; init; }

    /// <summary>
    /// <c>Controlled Airspace Classification (ARSP CLASS)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.215.</remarks>
    [Character(17)]
    public char Classification { get; init; }

    /// <summary>
    /// <c>Multiple Code (MULTI CD)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.130.</remarks>
    [Character(20)]
    public char MultipleCode { get; init; }

    /// <summary>
    /// <c>Level (LEVEL)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.19.</remarks>
    [Character(26)]
    public char Level { get; init; }

    /// <summary>
    /// <c>Time Code (TIME CD)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.131.</remarks>
    [Character(27)]
    public char TimeCode { get; init; }

    /// <summary>
    /// <c>NOTAM</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.132.</remarks>
    [Character(28)]
    public char Notam { get; init; }

    /// <summary>
    /// <c>Required Navigation Performance (RNP)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.211.</remarks>
    [Field(79, 81)]
    public string? RequiredNavigationPerformance { get; init; }

    /// <summary>
    /// <c>Lower Limit</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.121.</remarks>
    [Field(82, 86)]
    public string LowerLimit { get; init; }

    /// <summary>
    /// <c>Unit Indicator (UNIT IND)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.133.</remarks>
    [Character(87)]
    public char LowerLimitUnit { get; init; }

    /// <summary>
    /// <c>UpperLimit</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.121.</remarks>
    [Field(88, 92)]
    public string UpperLimit { get; init; }

    /// <summary>
    /// <c>Unit Indicator (UNIT IND)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.133.</remarks>
    [Character(93)]
    public char UpperLimitUnit { get; init; }

    /// <summary>
    /// <c>Controlled Airspace Name (ARSP NAME)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.216.</remarks>
    [Field(94, 123)]
    public string Name { get; init; }
}
