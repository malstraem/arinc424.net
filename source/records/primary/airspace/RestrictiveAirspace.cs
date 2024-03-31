using System.Diagnostics;

using Arinc.Spec424.Attributes;

namespace Arinc.Spec424.Records;

#pragma warning disable CS8618

/// <summary>
/// <c>Restrictive Airspace</c> primary record.
/// </summary>
/// <remarks>See section 4.1.18.1.</remarks>
[Record('U', 'R'), Continuous(25), Sequenced(21, 24)]
[DebuggerDisplay($"{{{nameof(AreaCode)}}}, {{{nameof(Name)}}}")]
public class RestrictiveAirspace : Record424<BoundaryPoint>, IIcao
{
    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See section 5.14.</remarks>
    [Field(7, 8)]
    public string IcaoCode { get; init; }

    /// <summary>
    /// <c>Restrictive Airspace Type (REST TYPE)</c> character.
    /// </summary>
    /// <remarks>See section 5.128.</remarks>
    [Character(9)]
    public char Type { get; init; }

    /// <summary>
    /// <c>Restrictive Airspace Designation</c> field.
    /// </summary>
    /// <remarks>See section 5.129.</remarks>
    [Field(10, 19)]
    public string Designation { get; init; }

    /// <summary>
    /// <c>Multiple Code (MULTI CD)</c> character.
    /// </summary>
    /// <remarks>See section 5.130.</remarks>
    [Character(20)]
    public char MultipleCode { get; init; }

    /// <summary>
    /// <c>Level (LEVEL)</c> character.
    /// </summary>
    /// <remarks>See section 5.19.</remarks>
    [Character(26)]
    public char Level { get; init; }

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
    /// <c>Upper Limit</c> field.
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
    /// <c>Restrictive Airspace Name</c> field.
    /// </summary>
    /// <remarks>See section 5.126.</remarks>
    [Field(94, 123)]
    public string Name { get; init; }
}
