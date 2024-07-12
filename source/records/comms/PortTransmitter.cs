namespace Arinc424.Comms;

using Terms;

/// <summary>
/// Fields of <c>Airport Communications</c> and <c>Heliport Communications</c>.
/// </summary>
/// <remarks>Used by <see cref="AirportCommunication"/> or <see cref="HeliportCommunication"/> like subsequence.</remarks>
public class PortTransmitter : Transmitter
{
    /// <summary>
    /// <c>Multi-Sector Indicator (MSEC IND)</c> character.
    /// </summary>
    /// <remarks>See section 5.286.</remarks>
    [Character(68, Supplement.V19)]
    public Bool IsMultiSector { get; set; }

    /// <summary>
    /// <c>Sectorization (SECTOR)</c> field.
    /// </summary>
    /// <remarks>See section 5.183.</remarks>
    [Field(63, 68), Field(69, 74, Supplement.V19)]
    public Sectorization? Sectorization { get; set; }

    [Type(81, 82)]
    [Identifier(75, 78), Icao(79, 80)]
    public Geo? Facility { get; set; }

    /// <inheritdoc cref="DistanceLimitation"/>
    [Character(88), Character(90, Supplement.V19)]
    public DistanceLimitation Limitation { get; set; }

    /// <summary>
    /// <c>Communications Distance (COMM DIST)</c> field.
    /// </summary>
    /// <value>Nautical miles.</value>
    /// <remarks>See section 5.188.</remarks>
    [Integer]
    [Field(89, 90), Field(91, 92, Supplement.V19)]
    public int Distance { get; set; }

    /// <inheritdoc cref="PortCommUsages"/>
    [Field(27, 29), Field(112, 114, Supplement.V19)]
    public PortCommUsages Usages { get; set; }
}
