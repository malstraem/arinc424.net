using System.Diagnostics;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Terms.Subsequences;

namespace Arinc.Spec424.Records;

/// <summary>
/// <c>Restrictive Airspace</c> primary record.
/// </summary>
/// <remarks>See paragraph 4.1.18.1.</remarks>
[Record('U', 'R'), Continuation(25), Sequenced(21, 24)]
[DebuggerDisplay("Area - {AreaCode}, Name - {Name}")]
public record RestrictiveAirspace : SequencedRecord424<BoundaryPoint>
{
    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.14.</remarks>
    [Field(7, 8)]
    public required string IcaoCode { get; init; }

    /// <summary>
    /// <c>Restrictive Airspace Type (REST TYPE)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.128.</remarks>
    [Character(9)]
    public required char Type { get; init; }

    /// <summary>
    /// <c>Restrictive Airspace Designation</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.129.</remarks>
    [Field(10, 19)]
    public required string Designation { get; init; }

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
    /// <c>Upper Limit</c> field.
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
    /// <c>Restrictive Airspace Name</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.126.</remarks>
    [Field(94, 123)]
    public required string Name { get; init; }
}
