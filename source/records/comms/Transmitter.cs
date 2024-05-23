namespace Arinc424.Comms;

using Terms;

#pragma warning disable CS8618

[DebuggerDisplay($"{nameof(CallSign)} - {{{nameof(CallSign)}}}, {nameof(Type)} - {{{nameof(Type)}}}")]
public abstract class Transmitter : Geo
{
    /// <inheritdoc cref="CommType"/>
    [Field(23, 25)]
    public CommType Type { get; set; }

    /// <inheritdoc cref="Arinc424.Frequency"/>
    [Field(26, 40)]
    public Frequency Frequency { get; set; }

    /// <summary>
    /// <c>Radar (RADAR)</c> character.
    /// </summary>
    /// <remarks>See section 5.102.</remarks>
    [Character(41), Transform<RadarAvailabilityConverter>]
    public Bool IsRadarAvailable { get; set; }

    /// <summary>
    /// <c>H24 Indicator (H24)</c> character.
    /// </summary>
    /// <remarks>See section 5.181.</remarks>
    [Character(42)]
    public Bool IsWholeDay { get; set; }

    /// <summary>
    /// <c>Call Sign (CALL SIGN)</c> field.
    /// </summary>
    /// <remarks>See section 5.105.</remarks>
    [Field(43, 67)]
    public string CallSign { get; set; }

    /// <inheritdoc cref="Arinc424.AltitudeDescription"/>
    [Character(83), Character<AirwayTransmitter>(117)]
    public AltitudeDescription AltitudeDescription { get; set; }

    /// <summary>
    /// <c>Communication Altitude (COMM ALTITUDE)</c> field.
    /// </summary>
    /// <value>Hundredth of feet.</value>
    /// <remarks>See section 5.184.</remarks>
    [Field(84, 86), Field<AirwayTransmitter>(118, 120), Decode<IntConverter>]
    public int Altitude { get; set; }

    /// <inheritdoc cref="Altitude"/>
    [Field(87, 89), Field<AirwayTransmitter>(121, 123), Decode<IntConverter>]
    public int Altitude2 { get; set; }

    /// <inheritdoc cref="Terms.Modulation"/>
    [Character(115)]
    public Modulation Modulation { get; set; }

    /// <inheritdoc cref="Terms.Emission"/>
    [Character(116)]
    public Emission Emission { get; set; }
}
