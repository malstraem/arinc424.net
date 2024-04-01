using System.Diagnostics;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Converters;
using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Records;

#pragma warning disable CS8618

/// <summary>
/// <c>Restrictive Airspace</c> primary record.
/// </summary>
/// <remarks>See section 4.1.18.1.</remarks>
[Record('U', 'R'), Continuous(25), Sequenced(21, 24)]
[DebuggerDisplay($"{{{nameof(IcaoCode)}}}, {{{nameof(Designation)}}}")]
public class RestrictiveAirspace : Volume, IIcao
{
    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See section 5.14.</remarks>
    [Field(7, 8)]
    public string IcaoCode { get; init; }

    /// <inheritdoc cref="RestrictiveType"/>
    [Character(9), Transform<RestrictiveTypeConverter>]
    public RestrictiveType Type { get; init; }

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

    /// <summary>
    /// <c>Restrictive Airspace Name</c> field.
    /// </summary>
    /// <remarks>See section 5.126.</remarks>
    [Field(94, 123)]
    public string? Name { get; init; }
}
