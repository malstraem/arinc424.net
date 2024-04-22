using System.Diagnostics;

using Arinc424.Attributes;
using Arinc424.Converters;

namespace Arinc424.Airspace;

#pragma warning disable CS8618

/// <summary>
/// <c>Controlled Airspace</c> primary record.
/// </summary>
/// <remarks>See section 4.1.25.1.</remarks>
[Section('U', 'C'), Continuous(25), Sequenced(21, 24)]
[DebuggerDisplay($"{{{nameof(AreaCode)}}}, {nameof(Name)} - {{{nameof(Name)}}}")]
public class ControlledAirspace : Volume, IIcao
{
    [Field(7, 8)]
    public string IcaoCode { get; set; }

    /// <inheritdoc cref="Terms.AirspaceType"/>
    [Character(9), Transform<AirspaceTypeConverter>]
    public Terms.AirspaceType Type { get; set; }

    /// <summary>
    /// <c>Controlled Airspace Center (ARSP CNTR)</c> field.
    /// </summary>
    /// <remarks>See section 5.214.</remarks>
    [Type(15, 16)]
    [Foreign(10, 14), Foreign(7, 8)]
    public IIdentity Center { get; set; }

    /// <inheritdoc cref="Terms.AirspaceClass"/>
    [Character(17), Transform<AirspaceClassConverter>]
    public Terms.AirspaceClass Class { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='MultipleCode']/*"/>
    [Character(20)]
    public char MultipleCode { get; set; }

    /// <inheritdoc cref="Arinc424.LevelType"/>
    [Character(26), Transform<LevelTypeConverter>]
    public LevelType LevelType { get; set; }

    /// <inheritdoc cref="Arinc424.TimeCode"/>
    [Character(27), Transform<TimeCodeConverter>]
    public TimeCode TimeCode { get; set; }

    /// <summary>
    /// <c>NOTAM</c> character.
    /// </summary>
    /// <remarks>See section 5.132.</remarks>
    [Character(28)]
    public char Notam { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='RNP']/*"/>
    [Field(79, 81), Decode<NavigationPerformanceConverter>]
    public float NavigationPerformance { get; set; }

    /// <summary>
    /// <c>Controlled Airspace Name (ARSP NAME)</c> field.
    /// </summary>
    /// <remarks>See section 5.216.</remarks>
    [Field(94, 123)]
    public string? Name { get; set; }
}
