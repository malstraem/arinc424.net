using Arinc424.Ports;

namespace Arinc424.Navigation;

/// <summary>
/// <c>VHF NAVAID</c> primary record.
/// </summary>
/// <remarks>See section 4.1.2.1.</remarks>
[Section('D'), Continuous]
public class OmnidirectionalStation : Navaid
{
    [Foreign(7, 12)]
    public Airport? Airport { get; set; }

    /// <summary>
    /// <c>DME Identifier (DME IDENT)</c> field.
    /// </summary>
    /// <remarks>See section 5.38.</remarks>
    [Field(52, 55)]
    public string? EquipmentIdentifier { get; set; }

    [Field(56, 74)]
    public Coordinates? EquipmentCoordinates { get; set; }

    /// <summary>
    /// <c>Station Declination (STN DEC)</c> field.
    /// </summary>
    /// <remarks>See section 5.66.</remarks>
    [Field(75, 79), Obsolete("todo")]
    public string? StationDeclination { get; set; }

    /// <summary>
    /// <c>DME Elevation (DME ELEV)</c> field.
    /// </summary>
    /// <remarks>See section 5.40.</remarks>
    [Field(80, 84), Integer]
    public int EquipmentElevation { get; set; }

    /// <inheritdoc cref="Terms.MeritFigure"/>
    [Character(85)]
    public Terms.MeritFigure MeritFigure { get; set; }

    /// <summary>
    /// <c>ILS/DME Bias</c> field.
    /// </summary>
    /// <value>Nautical miles and tenths of mile.</value>
    /// <remarks>See section 5.90.</remarks>
    [Field(86, 87), Float(10)]
    public float EquipmentOffset { get; set; }

    /// <summary>
    /// <c>Frequency Protection Distance (FREQ PRD)</c> field.
    /// </summary>
    /// <value>Nautical miles.</value>
    /// <remarks>See section 5.150.</remarks>
    [Field(88, 90), Integer]
    public int ProtectionDistance { get; set; }

    /// <summary>
    /// <c>Route Inappropriate Navaid Indicator</c> character.
    /// </summary>
    /// <remarks>See section 5.297.</remarks>
    [Character(122)]
    public Bool NotAreaNavigation { get; set; }

    /// <inheritdoc cref="Terms.ServiceVolume"/>
    [Character(123)]
    public Terms.ServiceVolume ServiceVolume { get; set; }
}
