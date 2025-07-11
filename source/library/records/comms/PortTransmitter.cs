namespace Arinc424.Comms;

/**<summary>
Fields of <c>Airport Communications</c> and <c>Heliport Communications</c>.
</summary>
<remarks>Used by <see cref="PortCommunication"/> like subsequence.</remarks>*/
[DebuggerDisplay($"{{{nameof(CallSign)},nq}}, {nameof(Type)} - {{{nameof(Type)}}}")]
public class PortTransmitter : Transmitter
{
    /**<summary>
    <c>Multi-Sector Indicator (MSEC IND)</c> character.
    </summary>
    <remarks>See section 5.286.</remarks>*/
    [Character(68, Start = Supplement.V19)]
    public Bool IsMultiSector { get; set; }

    /**<summary>
    <c>Sectorization (SECTOR)</c> field.
    </summary>
    <remarks>See section 5.183.</remarks>*/
    [Field(63, 68), Field(69, 74, Start = Supplement.V19)]
    public Sectorization? Sectorization { get; set; }

    [Known(80, 83), Known(75, 78, Start = Supplement.V19)]
    [Icao(84, 85), Icao(79, 80, Start = Supplement.V19)]
    [Type(86, 87), Type(81, 82, Start = Supplement.V19)]
    public Fix? Facility { get; set; }

    /// <inheritdoc cref="Terms.DistanceLimitation"/>
    [Character(88), Character(90, Start = Supplement.V19)]
    public Terms.DistanceLimitation Limitation { get; set; }

    /**<summary>
    <c>Communications Distance (COMM DIST)</c> field.
    </summary>
    <value>Nautical miles.</value>
    <remarks>See section 5.188.</remarks>*/
    [Integer]
    [Field(89, 90), Field(91, 92, Start = Supplement.V19)]
    public int Distance { get; set; }

    /// <inheritdoc cref="Terms.PortCommUsages"/>
    [Field(27, 29), Field(112, 114, Start = Supplement.V19)]
    public Terms.PortCommUsages Usages { get; set; }
}
