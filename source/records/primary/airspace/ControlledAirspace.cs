using System.Diagnostics;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Converters;
using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Records;

#pragma warning disable CS8618

/// <summary>
/// <c>Controlled Airspace</c> primary record.
/// </summary>
/// <remarks>See section 4.1.25.1.</remarks>
[Record('U', 'C'), Continuous(25), Sequenced(21, 24)]
[DebuggerDisplay($"{{{nameof(AreaCode)}}}, {{{nameof(Name)}}}")]
public class ControlledAirspace : Record424<BoundaryPoint>, IIcao
{
    [Field(7, 8)]
    public string IcaoCode { get; init; }

    /// <inheritdoc cref="AirspaceType"/>
    [Character(9), Transform<AirspaceTypeConverter>]
    public AirspaceType Type { get; init; }

    /// <summary>
    /// <c>Controlled Airspace Center (ARSP CNTR)</c> field.
    /// </summary>
    /// <remarks>See section 5.214.</remarks>
    [Field(10, 14)]
    public string Center { get; init; }

    /// <summary>
    /// <c>Section Code (SEC CODE)</c> character.
    /// </summary>
    /// <remarks>See section 5.4.</remarks>
    [Character(15)]
    public char SectionLink { get; init; }

    /// <summary>
    /// <c>Subsection Code (SUB CODE)</c> character.
    /// </summary>
    /// <remarks>See section 5.5.</remarks>
    [Character(16)]
    public char SubsectionLink { get; init; }

    /// <summary>
    /// <c>Controlled Airspace Classification (ARSP CLASS)</c> character.
    /// </summary>
    /// <remarks>See section 5.215.</remarks>
    [Character(17)]
    public char Classification { get; init; }

    /// <summary>
    /// <c>Multiple Code (MULTI CD)</c> character.
    /// </summary>
    /// <remarks>See section 5.130.</remarks>
    [Character(20)]
    public char MultipleCode { get; init; }

    /// <inheritdoc cref="Terms.LevelType"/>
    [Character(26), Transform<LevelTypeConverter>]
    public LevelType LevelType { get; init; }

    /// <summary>
    /// <c>Time Code (TIME CD)</c> character.
    /// </summary>
    /// <remarks>See section 5.131.</remarks>
    [Character(27)]
    public char TimeCode { get; init; }

    /// <summary>
    /// <c>NOTAM</c> character.
    /// </summary>
    /// <remarks>See section 5.132.</remarks>
    [Character(28)]
    public char Notam { get; init; }

    /// <include file='Comments.xml' path="doc/members/member[@name='RNP']/*"/>
    [Field(79, 81), Decode<RnpConverter>]
    public float NavigationPerformance { get; init; }

    /// <summary>
    /// <c>Lower Limit</c> field.
    /// </summary>
    /// <remarks>See section 5.121.</remarks>
    [Field(82, 86)]
    public string LowerLimit { get; init; }

    /// <summary>
    /// <c>Unit Indicator (UNIT IND)</c> character.
    /// </summary>
    /// <remarks>See section 5.133.</remarks>
    [Character(87)]
    public char LowerLimitUnit { get; init; }

    /// <summary>
    /// <c>UpperLimit</c> field.
    /// </summary>
    /// <remarks>See section 5.121.</remarks>
    [Field(88, 92)]
    public string UpperLimit { get; init; }

    /// <summary>
    /// <c>Unit Indicator (UNIT IND)</c> character.
    /// </summary>
    /// <remarks>See section 5.133.</remarks>
    [Character(93)]
    public char UpperLimitUnit { get; init; }

    /// <summary>
    /// <c>Controlled Airspace Name (ARSP NAME)</c> field.
    /// </summary>
    /// <remarks>See section 5.216.</remarks>
    [Field(94, 123)]
    public string? Name { get; init; }
}