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
    [Character(68)]
    public Bool IsMultiSector { get; set; }

    /// <summary>
    /// <c>Sectorization (SECTOR)</c> field.
    /// </summary>
    /// <remarks>See section 5.183.</remarks>
    [Field(69, 74)]
    public Sectorization? Sectorization { get; set; }

    [Type(81, 82)]
    [Foreign(75, 80)]
    public Geo? Facility { get; set; }

    /// <inheritdoc cref="DistanceLimitation"/>
    [Character(90)]
    public DistanceLimitation Limitation { get; set; }

    /// <summary>
    /// <c>Communications Distance (COMM DIST)</c> field.
    /// </summary>
    /// <value>Nautical miles.</value>
    /// <remarks>See section 5.188.</remarks>
    [Field(91, 92), Integer]
    public int Distance { get; set; }

    /// <inheritdoc cref="PortCommUsages"/>
    [Field(112, 114)]
    public PortCommUsages Usages { get; set; }
}
