using System.Diagnostics;

using Arinc424.Attributes;
using Arinc424.Converters;

namespace Arinc424.Comms;

[DebuggerDisplay($"{{{nameof(CallSign)}}}, {nameof(Type)} - {{{nameof(Type)}}}")]
public abstract class Transmitter : Geo
{
    /// <inheritdoc cref="Terms.CommType"/>
    [Field(23, 25), Decode<CommTypeConverter>]
    public Terms.CommType Type { get; set; }

    /// <summary>
    /// <c>Communications Frequency (COMM FREQ)</c> field
    /// </summary>
    /// <remarks>See section 5.103.</remarks>
    [Field(26, 40), Decode<FrequencyConverter>]
    public Terms.Frequency Frequency { get; set; }

    [Character(41)]
    public char RadarUnits { get; set; }

    [Character(42)]
    public char H24Indicator { get; set; }

    [Field(43, 67)]
    public string CallSign { get; set; }

    /// <inheritdoc cref="Terms.SectorIndicator"/>
    [Character(68), Transform<SectorIndicatorConverter>]
    public Terms.SectorIndicator SectorIndicator { get; set; }

    /// <inheritdoc cref="Terms.Sector"/>
    [Field(69, 74)]
    public Terms.Sector Sector { get; set; }

    [Type(81, 82)]
    [Foreign(75, 80)]
    public Geo? Facility { get; set; }

    /// <inheritdoc cref="Arinc424.AltitudeDescription"/>
    [Character(83), Transform<AltitudeDescriptionConverter>]
    public AltitudeDescription AltitudeDescription { get; set; }

    /// <summary>
    /// <c>Communication Altitude (COMM ALTITUDE)</c> field.
    /// </summary>
    /// <value>Hundredth of feet.</value>
    /// <remarks>See section 5.184.</remarks>
    [Field(84, 86), Decode<IntConverter>]
    public int Altitude { get; set; }

    /// <inheritdoc cref="Altitude"/>
    [Field(87, 89), Decode<IntConverter>]
    public int Altitude2 { get; set; }

    /// <inheritdoc cref="Terms.DistanceLimitation"/>
    [Character(90), Transform<DistanceLimitationConverter>]
    public Terms.DistanceLimitation Limitation { get; set; }

    /// <summary>
    /// <c>Communications Distance (COMM DIST)</c> field.
    /// </summary>
    /// <value>Nautical miles.</value>
    /// <remarks>See section 5.188.</remarks>
    [Field(91, 92), Decode<IntConverter>]
    public int Distance { get; set; }

    [Character(115)]
    public char Modulation { get; set; }

    [Character(116)]
    public char Emission { get; set; }
}
