using Arinc424.Ground;

namespace Arinc424.Navigation;

using Terms;

/// <summary>
/// <c>TACAN-Only NAVAID</c> primary record.
/// </summary>
/// <remarks>See section 4.1.32.1.</remarks>
[Section('D', 'T'), Port(7, 10), Icao(11, 12)]
public class Tactical : Navaid
{
    [Identifier(7, 10)]
    public Airport Airport { get; set; }

    /// <inheritdoc cref="OmnidirectType"/>
    [Field(28, 29)]
    public OmnidirectType Type { get; set; }

    /// <inheritdoc cref="OmnidirectCoverage"/>
    [Character(30)]
    public OmnidirectCoverage Coverage { get; set; }

    /// <inheritdoc cref="OmnidirectInfo"/>
    [Character(31)]
    public OmnidirectInfo Info { get; set; }

    /// <inheritdoc cref="OmnidirectCollocation"/>
    [Character(32)]
    public OmnidirectCollocation Collocation { get; set; }

    /// <inheritdoc cref="Omnidirectional.EquipmentIdentifier"/>
    [Field(52, 55)]
    public string TacanIdentifier { get; set; }

    /// <inheritdoc cref="Terms.Declination"/>
    [Field(75, 79)]
    public Declination Declination { get; set; }

    /// <inheritdoc cref="Omnidirectional.EquipmentElevation"/>
    [Field(80, 84), Integer]
    public int Elevation { get; set; }

    /// <inheritdoc cref="UsableRange"/>
    [Character(85)]
    public UsableRange Range { get; set; }

    /// <inheritdoc cref="Omnidirectional.ProtectionDistance"/>
    [Field(88, 90), Integer]
    public int ProtectionDistance { get; set; }
}
