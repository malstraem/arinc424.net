using System.Diagnostics;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Terms;
using Arinc.Spec424.Terms.Converters;

namespace Arinc.Spec424.Records;

#pragma warning disable CS8618

/// <summary>
/// <c>Airport</c> primary record.
/// </summary>
/// <remarks>See paragraph 4.1.7.1.</remarks>
[Record('P', 'A', subsectionIndex: 13), Continuation]
[DebuggerDisplay("Identifier - {Identifier}, Name - {Name}")]
public class Airport : Geo, IIdentifiable
{
    /// <summary>
    /// <c>Airport Identifier (ARPT IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.6.</remarks>
    [Field(7, 10)]
    public string Identifier { get; init; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.14.</remarks>
    [Field(11, 12)]
    public string IcaoCode { get; init; }

    /// <summary>
    /// <c>ATA/IATA Designator (ATA/IATA)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.107.</remarks>
    [Field(14, 16)]
    public string? Designator { get; init; }

    /// <summary>
    /// <c>Speed Limit Altitude</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.73.</remarks>
    [Field(23, 27)]
    public string? SpeedLimitAltitude { get; init; }

    /// <summary>
    /// <c>Longest Runway (LONGEST RWY)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.54.</remarks>
    [Field(28, 30), Decode<NumericConverter>]
    public int LongestRunwayLength { get; init; }

    /// <summary>
    /// <c>IFR Capability (IFR)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.108.</remarks>
    [Character(31), Transform<BoolConverter>]
    public bool IsProcedureCapable { get; init; }

    /// <summary>
    /// <c>Longest Runway Surface Code (LRSC)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.249.</remarks>
    [Character(32), Transform<RunwaySurfaceTypeConverter>]
    public RunwaySurfaceType LongestRunwaySurfaceType { get; init; }

    /// <summary>
    /// <c>Magnetic Variation (MAG VAR, D MAG VAR)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.39.</remarks>
    [Field(52, 56), Decode<MagneticVariationConverter>]
    public float MagneticVariation { get; init; }

    /// <summary>
    /// <c>Airport Elevation (ELEV)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.55.</remarks>
    [Field(57, 61), Decode<NumericConverter>]
    public int Elevation { get; init; }

    /// <summary>
    /// <c>Speed Limit (SPEED LIMIT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.72.</remarks>
    [Field(62, 64)]
    public string? SpeedLimit { get; init; }

    /// <summary>
    /// <c>Recommended NAVAID (RECD NAV)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.23.</remarks>
    [Field(65, 68)]
    public string? RecommendedNavaid { get; init; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.14.</remarks>
    [Field(69, 70)]
    public string? RecommendedNavaidIcaoCode { get; init; }

    /// <summary>
    /// <c>Transition Altitude (TRANS ALTITUDE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.53.</remarks>
    [Field(71, 75), Decode<NumericConverter>]
    public int TransitionAltitude { get; init; }

    /// <summary>
    /// <c>Transition Level (TRANS LEVEL)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.53.</remarks>
    [Field(76, 80),]
    public string? TransitionLevel { get; init; }

    /// <summary>
    /// Airport privacy.
    /// </summary>
    [Character(81), Transform<PortPrivacyConverter>]
    public PortPrivacy Privacy { get; init; }

    /// <summary>
    /// <c>Time Zone</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.178.</remarks>
    [Field(82, 84),]
    public string TimeZone { get; init; }

    /// <summary>
    /// <c>Daylight Time Indicator (DAY TIME)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.179.</remarks>
    [Character(85), Transform<BoolConverter>]
    public bool IsDaylightTime { get; init; }

    /// <summary>
    /// Bearing and course type.
    /// </summary>
    [Character(86), Transform<CourseTypeConverter>]
    public CourseType CourseType { get; init; }

    /// <summary>
    /// <c>Datum Code (DATUM)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.197.</remarks>
    [Field(87, 89)]
    public string DatumCode { get; init; }

    /// <summary>
    /// <c>Name</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.71.</remarks>
    [Field(94, 123)]
    public string Name { get; init; }

    [Receive<Airport, Runway>]
    public IReadOnlyList<Runway> Runways { get; init; }

    [Receive<Airport, AirportApproach>]
    public IReadOnlyList<AirportApproach> Approaches { get; init; }

    [Receive<Airport, StandardTerminalArrival>]
    public IReadOnlyList<StandardTerminalArrival> Arrivals { get; init; }

    [Receive<Airport, StandardInstrumentDeparture>]
    public IReadOnlyList<StandardInstrumentDeparture> Departures { get; init; }

    [Receive<Airport, VeryHighFrequencyAid>]
    public IReadOnlyList<VeryHighFrequencyAid> VeryHighFrequencyAids { get; init; }

    [Receive<Airport, NonDirectionalBeacon>]
    public IReadOnlyList<NonDirectionalBeacon> NonDirectionalBeacons { get; init; }
}
