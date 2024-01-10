using System.Diagnostics;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Records;

/// <summary>
/// <c>Airport</c> primary record.
/// </summary>
/// <remarks>See paragraph 4.1.7.1.</remarks>
[Record('P', 'A', subsectionIndex: 13), Continuation]
[DebuggerDisplay("Identifier - {Identifier}, Name - {Name}")]
public class Airport : Record424, IIdentifiable
{
    /// <summary>
    /// <c>Airport Identifier (ARPT IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.6.</remarks>
    [Field(7, 10)]
    public required string Identifier { get; init; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.14.</remarks>
    [Field(11, 12)]
    public required string IcaoCode { get; init; }

    /// <summary>
    /// <c>ATA/IATA Designator (ATA/IATA)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.107.</remarks>
    [Field(14, 16)]
    public required string Designator { get; init; }

    /// <summary>
    /// <c>Speed Limit Altitude</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.73.</remarks>
    [Field(23, 27)]
    public required string? SpeedLimitAltitude { get; init; }

    /// <summary>
    /// <c>Longest Runway (LONGEST RWY)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.54.</remarks>
    [Field(28, 30)]
    public required string LongestRunway { get; init; }

    /// <summary>
    /// <c>IFR Capability (IFR)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.108.</remarks>
    [Character(31)]
    public required char ProcedureCapability { get; init; }

    /// <summary>
    /// <c>Longest Runway Surface Code (LRSC)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.249.</remarks>
    [Character(32)]
    public required char LongestRunwaySurfaceCode { get; init; }

    /// <summary>
    /// <c>Latitude (LATITUDE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.36.</remarks>
    [Field(33, 41)]
    public required string AirportReferencePointLatitude { get; init; }

    /// <summary>
    /// <c>Longitude (LONGITUDE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.37.</remarks>
    [Field(42, 51)]
    public required string AirportReferencePointLongitude { get; init; }

    /// <summary>
    /// <c>Magnetic Variation (MAG VAR, D MAG VAR)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.39.</remarks>
    [Field(52, 56)]
    public required string MagneticVariation { get; init; }

    /// <summary>
    /// <c>Airport Elevation (ELEV)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.55.</remarks>
    [Field(57, 61)]
    public required string AirportElevation { get; init; }

    /// <summary>
    /// <c>Speed Limit (SPEED LIMIT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.72.</remarks>
    [Field(62, 64)]
    public required string? SpeedLimit { get; init; }

    /// <summary>
    /// <c>Recommended NAVAID (RECD NAV)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.23.</remarks>
    [Field(65, 68)]
    public required string? RecommendedNavaid { get; init; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.14.</remarks>
    [Field(69, 70)]
    public required string? RecommendedNavaidIcaoCode { get; init; }

    /// <summary>
    /// <c>Transition Altitude (TRANS ALTITUDE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.53.</remarks>
    [Field(71, 75)]
    public required string TransitionAltitude { get; init; }

    /// <summary>
    /// <c>Transition Level (TRANS LEVEL)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.53.</remarks>
    [Field(76, 80)]
    public required string? TransitionLevel { get; init; }

    /// <summary>
    /// <c>Public/Military Indicator (PUB/MIL)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.177.</remarks>
    [Character(81)]
    public required char PublicMilitaryIndicator { get; init; }

    /// <summary>
    /// <c>Time Zone</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.178.</remarks>
    [Field(82, 84)]
    public required string TimeZone { get; init; }

    /// <summary>
    /// <c>Daylight Time Indicator (DAY TIME)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.179.</remarks>
    [Character(85)]
    public required char DaylightIndicator { get; init; }

    /// <summary>
    /// <c>Magnetic/True Indicator (M/T IND)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.165.</remarks>
    [Character(86)]
    public required char MagneticOrTrueIndicator { get; init; }

    /// <summary>
    /// <c>Datum Code (DATUM)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.197.</remarks>
    [Field(87, 89)]
    public required string DatumCode { get; init; }

    /// <summary>
    /// <c>Name</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.71.</remarks>
    [Field(94, 123)]
    public required string Name { get; init; }

    [Receive<Airport, Runway>]
    public required IReadOnlyList<Runway> Runways { get; set; }

    [Receive<Airport, AirportApproach>]
    public required IReadOnlyList<AirportApproach> Approaches { get; set; }

    [Receive<Airport, StandardTerminalArrival>]
    public required IReadOnlyList<StandardTerminalArrival> Arrivals { get; set; }

    [Receive<Airport, StandardInstrumentDeparture>]
    public required IReadOnlyList<StandardInstrumentDeparture> Departures { get; set; }

    [Receive<Airport, VeryHighFrequencyAid>]
    public required IReadOnlyList<VeryHighFrequencyAid> VeryHighFrequencyAids { get; set; }

    [Receive<Airport, NonDirectionalBeacon>]
    public required IReadOnlyList<NonDirectionalBeacon> NonDirectionalBeacons { get; set; }
}
