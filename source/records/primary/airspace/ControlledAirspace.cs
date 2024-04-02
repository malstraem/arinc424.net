using System.Diagnostics;

using Arinc424.Attributes;
using Arinc424.Converters;

namespace Arinc424.Airspace;

#pragma warning disable CS8618

/// <summary>
/// <c>Controlled Airspace</c> primary record.
/// </summary>
/// <remarks>See section 4.1.25.1.</remarks>
[Record('U', 'C'), Continuous(25), Sequenced(21, 24)]
[DebuggerDisplay($"{{{nameof(AreaCode)}}}, {{{nameof(Name)}}}")]
public class ControlledAirspace : Volume, IIcao
{
    [Field(7, 8)]
    public string IcaoCode { get; set; }

    /// <inheritdoc cref="AirspaceType"/>
    [Character(9), Transform<AirspaceTypeConverter>]
    public Terms.AirspaceType Type { get; set; }

    /// <summary>
    /// <c>Controlled Airspace Center (ARSP CNTR)</c> field.
    /// </summary>
    /// <remarks>See section 5.214.</remarks>
    [Type(15, 16)]
    [Foreign(10, 14), Foreign(7, 8)]
    public Geo Center { get; set; }

    /// <inheritdoc cref="AirspaceClass"/>
    [Character(17), Transform<AirspaceClassConverter>]
    public Terms.AirspaceClass Class { get; set; }

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

    /// <include file='Comments.xml' path="doc/members/member[@name='RNP']/*"/>
    [Field(79, 81), Decode<NavigationPerformanceConverter>]
    public float NavigationPerformance { get; set; }

    /// <summary>
    /// <c>Controlled Airspace Name (ARSP NAME)</c> field.
    /// </summary>
    /// <remarks>See section 5.216.</remarks>
    [Field(94, 123)]
    public string? Name { get; set; }
}
