using System.Diagnostics;

using Arinc424.Attributes;
using Arinc424.Converters;
using Arinc424.Ports;

namespace Arinc424.Navigation;

#pragma warning disable CS8618

/// <summary>
/// <c>VHF NAVAID</c> primary record.
/// </summary>
/// <remarks>See section 4.1.2.1.</remarks>
[Record('D'), Continuous]
[DebuggerDisplay($"{{{nameof(Identifier)}}}, Name - {{{nameof(Name)}}}")]
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

    [Field(56, 74), Decode<CoordinatesConverter>]
    public Coordinates? EquipmentCoordinates { get; set; }

    /// <summary>
    /// <c>Station Declination (STN DEC)</c> field.
    /// </summary>
    /// <remarks>See section 5.66.</remarks>
    [Field(75, 79)]
    public string? StationDeclination { get; set; }

    /// <summary>
    /// <c>DME Elevation (DME ELEV)</c> field.
    /// </summary>
    /// <remarks>See section 5.40.</remarks>
    [Field(80, 84), Decode<IntConverter>]
    public int EquipmentElevation { get; set; }

    /// <inheritdoc cref="Terms.MeritFigure"/>
    [Character(85), Transform<MeritFigureConverter>]
    public Terms.MeritFigure MeritFigure { get; set; }

    /// <summary>
    /// <c>ILS/DME Bias</c> field.
    /// </summary>
    /// <value>Nautical miles and tenths of mile.</value>
    /// <remarks>See section 5.90.</remarks>
    [Field(86, 87), Decode<TenthsConverter>]
    public float EquipmentOffset { get; set; }

    /// <summary>
    /// <c>Frequency Protection Distance (FREQ PRD)</c> field.
    /// </summary>
    /// <value>Nautical miles.</value>
    /// <remarks>See section 5.150.</remarks>
    [Field(88, 90), Decode<IntConverter>]
    public int ProtectionDistance { get; set; }

    /// <summary>
    /// <c>Route Inappropriate Navaid Indicator</c> character.
    /// </summary>
    /// <remarks>See section 5.297.</remarks>
    [Character(122), Transform<BoolConverter>]
    public bool NotAreaNavigation { get; set; }

    /// <inheritdoc cref="Terms.ServiceVolume"/>
    [Character(123), Transform<ServiceVolumeConverter>]
    public Terms.ServiceVolume ServiceVolume { get; set; }
}
