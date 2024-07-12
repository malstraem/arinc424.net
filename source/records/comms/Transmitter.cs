namespace Arinc424.Comms;

using Terms;

[DebuggerDisplay($"{{{nameof(CallSign)},nq}}, {nameof(Type)} - {{{nameof(Type)}}}")]
public abstract class Transmitter : Geo
{
    /// <inheritdoc cref="CommType"/>
    [Field(14, 16), Field(23, 25, Supplement.V19)]
    public CommType Type { get; set; }

    /// <inheritdoc cref="Arinc424.Frequency"/>
    [Field(17, 25), Field(26, 40, Supplement.V19)]
    public Frequency Frequency { get; set; }

    /// <summary>
    /// <c>Radar (RADAR)</c> character.
    /// </summary>
    /// <remarks>See section 5.102.</remarks>
    [Character(30), Character(41, Supplement.V19)]
    [Transform<RadarAvailabilityConverter, Bool>]
    public Bool IsRadarAvailable { get; set; }

    /// <summary>
    /// <c>H24 Indicator (H24)</c> character.
    /// </summary>
    /// <remarks>See section 5.181.</remarks>
    [Character(62), Character(42, Supplement.V19)]
    public Bool IsWholeDay { get; set; }

    /// <summary>
    /// <c>Call Sign (CALL SIGN)</c> field.
    /// </summary>
    /// <remarks>See section 5.105.</remarks>
    [Field(99, 123), Field(43, 67, Supplement.V19)]
    public string CallSign { get; set; }

    /// <inheritdoc cref="Arinc424.AltitudeDescription"/>
    [Character(69), Character(83, Supplement.V19)]
    [Character<AirwayTransmitter>(93), Character<AirwayTransmitter>(117, Supplement.V19)]
    [Character(69, Supplement.V18)]
    public AltitudeDescription AltitudeDescription { get; set; }

    /// <summary>
    /// <c>Communication Altitude (COMM ALTITUDE)</c> field.
    /// </summary>
    /// <value>Hundredth of feet.</value>
    /// <remarks>See section 5.184.</remarks>
    [Integer]
    [Field(70, 74), Field(84, 86, Supplement.V19)]
    [Field<AirwayTransmitter>(94, 98), Field<AirwayTransmitter>(118, 120, Supplement.V19)]
    public int Altitude { get; set; }

    /// <inheritdoc cref="Altitude"/>
    [Integer]
    [Field(75, 79), Field(87, 89, Supplement.V19)]
    [Field<AirwayTransmitter>(99, 103), Field<AirwayTransmitter>(121, 123, Supplement.V19)]
    public int Altitude2 { get; set; }

    /// <inheritdoc cref="Terms.Modulation"/>
    [Character(61), Character(115, Supplement.V19)]
    public Modulation Modulation { get; set; }

    /// <inheritdoc cref="Terms.Emission"/>
    [Character(61), Character(116, Supplement.V19)]
    public Emission Emission { get; set; }
}
