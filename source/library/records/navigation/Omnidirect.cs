namespace Arinc424.Navigation;

/**<summary>
<c>VHF NAVAID</c> primary record.
</summary>
<remarks>See section 4.1.2.1.</remarks>*/
[Section('D'), Port(7, 10), Icao(20, 21)]
public class Omnidirect : Navaid
{
    public Ground.Port? Port { get; set; }

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

    /**<summary>
    <c>DME Identifier (DME IDENT)</c> field.
    </summary>
    <remarks>See section 5.38.</remarks>*/
    [Field(52, 55)]
    public string? EquipmentIdentifier { get; set; }

    [Field(56, 74)]
    public Coordinates? EquipmentCoordinates { get; set; }

    /// <inheritdoc cref="Terms.Declination"/>
    [Field(75, 79)]
    public Terms.Declination Declination { get; set; }

    /**<summary>
    <c>DME Elevation (DME ELEV)</c> field.
    </summary>
    <remarks>See section 5.40.</remarks>*/
    [Field(80, 84), Integer]
    public int EquipmentElevation { get; set; }

    /// <inheritdoc cref="Terms.UsableRange"/>
    [Character(85)]
    public Terms.UsableRange Range { get; set; }

    /**<summary>
    <c>ILS/DME Bias</c> field.
    </summary>
    <value>Nautical miles.</value>
    <remarks>See section 5.90.</remarks>*/
    [Field(86, 87), Float(10)]
    public float EquipmentOffset { get; set; }

    /**<summary>
    <c>Frequency Protection Distance (FREQ PRD)</c> field.
    </summary>
    <value>Nautical miles.</value>
    <remarks>See section 5.150.</remarks>*/
    [Field(88, 90), Integer]
    public int ProtectionDistance { get; set; }

    /**<summary>
    <c>Route Inappropriate Navaid Indicator</c> character.
    </summary>
    <remarks>See section 5.297.</remarks>*/
    [Character(122, Start = Supplement.V20)]
    public Bool NotAreaNavigation { get; set; }

    /// <inheritdoc cref="Terms.ServiceVolume"/>
    [Character(123, Start = Supplement.V19)]
    public Terms.ServiceVolume ServiceVolume { get; set; }
}
