namespace Arinc424.Comms;

using Terms;

public abstract class Transmitter : Geo
{
    /// <inheritdoc cref="CommType"/>
    [Field<AirwayTransmitter>(44, 46)]
    [Field<PortTransmitter>(14, 16)]
    [Field<Transmitter>(23, 25, Supplement.V19)]
    public CommType Type { get; set; }

    /// <inheritdoc cref="Arinc424.Frequency"/>
    [Field<AirwayTransmitter>(47, 55)]
    [Field<PortTransmitter>(17, 25)]
    [Field<Transmitter>(26, 40, Supplement.V19)]
    public Frequency Frequency { get; set; }

    /// <summary>
    /// <c>Radar (RADAR)</c> character.
    /// </summary>
    /// <remarks>See section 5.102.</remarks>
    [Character<AirwayTransmitter>(60)]
    [Character<PortTransmitter>(30)]
    [Character<Transmitter>(41, Supplement.V19)]
    [Transform<RadarAvailabilityConverter, Bool>]
    public Bool IsRadarAvailable { get; set; }

    /// <summary>
    /// <c>H24 Indicator (H24)</c> character.
    /// </summary>
    /// <remarks>See section 5.181.</remarks>
    [Character<AirwayTransmitter>(92)]
    [Character<PortTransmitter>(62)]
    [Character<Transmitter>(42, Supplement.V19)]
    public Bool IsWholeDay { get; set; }

    /// <summary>
    /// <c>Call Sign (CALL SIGN)</c> field.
    /// </summary>
    /// <remarks>See section 5.105.</remarks>
    [Field<PortTransmitter>(99, 123), Field<Transmitter>(43, 67, Supplement.V19)]
    public string? CallSign { get; set; }

    /// <inheritdoc cref="Arinc424.AltitudeDescription"/>
    [Character(69), Character(83, Supplement.V19)]
    [Character<AirwayTransmitter>(93), Character<AirwayTransmitter>(117, Supplement.V19)]
    public AltitudeDescription AltitudeDescription { get; set; }

    /// <summary>
    /// <c>Communication Altitude (COMM ALTITUDE)</c> field.
    /// </summary>
    /// <value>Hundredth of feet.</value>
    /// <remarks>See section 5.184.</remarks>
    [Field(70, 74), Field(84, 86, Supplement.V19)]
    [Field<AirwayTransmitter>(94, 98), Field<AirwayTransmitter>(118, 120, Supplement.V19)]
    [Decode<CommAltitudeConverter, Altitude>(Supplement.V19)]
    public Altitude Altitude { get; set; }

    /// <inheritdoc cref="Altitude"/>
    [Field(75, 79), Field(87, 89, Supplement.V19)]
    [Field<AirwayTransmitter>(99, 103), Field<AirwayTransmitter>(121, 123, Supplement.V19)]
    [Decode<CommAltitudeConverter, Altitude>(Supplement.V19)]
    public Altitude Altitude2 { get; set; }

    /// <inheritdoc cref="Terms.Modulation"/>
    [Character<AirwayTransmitter>(61)]
    [Character<PortTransmitter>(31)]
    [Character<Transmitter>(115, Supplement.V19)]
    public Modulation Modulation { get; set; }

    /// <inheritdoc cref="Terms.Emission"/>
    [Character<AirwayTransmitter>(62)]
    [Character<PortTransmitter>(32)]
    [Character<Transmitter>(116, Supplement.V19)]
    public Emission Emission { get; set; }
}
