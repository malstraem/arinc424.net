namespace Arinc424.Navigation;

/**<summary>
<c>TACAN-Only NAVAID</c> primary record.
</summary>
<remarks>See section 4.1.32.1.</remarks>*/
[Section('D', 'T'), Port(7, 10), Icao(11, 12)]
public class Tactical : Navaid
{
    [Identifier(7, 10)]
    public Ground.Port Port { get; set; }

    /// <inheritdoc cref="Terms.OmnidirectType"/>
    [Field(28, 29)]
    public Terms.OmnidirectType Type { get; set; }

    /// <inheritdoc cref="Terms.OmnidirectCoverage"/>
    [Character(30)]
    public Terms.OmnidirectCoverage Coverage { get; set; }

    /// <inheritdoc cref="Terms.OmnidirectInfo"/>
    [Character(31)]
    public Terms.OmnidirectInfo Info { get; set; }

    /// <inheritdoc cref="Terms.OmnidirectCollocation"/>
    [Character(32)]
    public Terms.OmnidirectCollocation Collocation { get; set; }

    /// <inheritdoc cref="Omnidirect.EquipmentIdentifier"/>
    [Field(52, 55)]
    public string TacanIdentifier { get; set; }

    /// <inheritdoc cref="Terms.Declination"/>
    [Field(75, 79)]
    public Terms.Declination Declination { get; set; }

    /// <inheritdoc cref="Omnidirect.EquipmentElevation"/>
    [Field(80, 84), Integer]
    public int Elevation { get; set; }

    /// <inheritdoc cref="Terms.UsableRange"/>
    [Character(85)]
    public Terms.UsableRange Range { get; set; }

    /// <inheritdoc cref="Omnidirect.ProtectionDistance"/>
    [Field(88, 90), Integer]
    public int ProtectionDistance { get; set; }
}
