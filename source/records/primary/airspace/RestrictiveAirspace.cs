using System.Diagnostics;

using Arinc424.Attributes;
using Arinc424.Converters;

namespace Arinc424.Airspace;

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
    public string IcaoCode { get; set; }

    /// <inheritdoc cref="RestrictiveType"/>
    [Character(9), Transform<RestrictiveTypeConverter>]
    public Terms.RestrictiveType Type { get; set; }

    /// <summary>
    /// <c>Restrictive Airspace Designation</c> field.
    /// </summary>
    /// <remarks>See section 5.129.</remarks>
    [Field(10, 19)]
    public string Designation { get; set; }

    /// <summary>
    /// <c>Multiple Code (MULTI CD)</c> character.
    /// </summary>
    /// <remarks>See section 5.130.</remarks>
    [Character(20)]
    public char MultipleCode { get; set; }

    /// <inheritdoc cref="Terms.LevelType"/>
    [Character(26), Transform<LevelTypeConverter>]
    public LevelType LevelType { get; set; }

    /// <summary>
    /// <c>Time Code (TIME CD)</c> character.
    /// </summary>
    /// <remarks>See section 5.131.</remarks>
    [Character(27)]
    public char TimeCode { get; set; }

    /// <summary>
    /// <c>NOTAM</c> character.
    /// </summary>
    /// <remarks>See section 5.132.</remarks>
    [Character(28)]
    public char Notam { get; set; }

    /// <summary>
    /// <c>Restrictive Airspace Name</c> field.
    /// </summary>
    /// <remarks>See section 5.126.</remarks>
    [Field(94, 123)]
    public string? Name { get; set; }
}
