using System.Diagnostics;

using Arinc424.Attributes;
using Arinc424.Converters;
using Arinc424.Navigation;
using Arinc424.Procedures;
using Arinc424.Waypoints;

namespace Arinc424.Ports;

#pragma warning disable CS8618

/// <summary>
/// <c>Airport</c> primary record.
/// </summary>
/// <remarks>See section 4.1.7.1.</remarks>
[Section('P', 'A', subsectionIndex: 13), Continuous]
[DebuggerDisplay($"{{{nameof(Identifier)}}}, {{{nameof(Name)}}}")]
public class Airport : Geo, IIcao, IIdentity
{
    /// <summary>
    /// <c>Airport Identifier (ARPT IDENT)</c> field.
    /// </summary>
    /// <remarks>See section 5.6.</remarks>
    [Field(7, 10), Primary]
    public string Identifier { get; set; }

    [Field(11, 12), Primary]
    public string IcaoCode { get; set; }

    /// <summary>
    /// <c>ATA/IATA Designator (ATA/IATA)</c> field.
    /// </summary>
    /// <remarks>See section 5.107.</remarks>
    [Field(14, 16)]
    public string? Designator { get; set; }

    /// <summary>
    /// <c>Speed Limit Altitude</c> field.
    /// </summary>
    /// <remarks>See section 5.73.</remarks>
    [Field(23, 27), Decode<AltitudeConverter>]
    public Altitude Limit { get; set; }

    /// <summary>
    /// <c>Longest Runway (LONGEST RWY)</c> field.
    /// </summary>
    /// <value>Hundreds of feet.</value>
    /// <remarks>See section 5.54.</remarks>
    [Field(28, 30), Decode<IntConverter>]
    public int LongestRunwayLength { get; set; }

    /// <summary>
    /// <c>IFR Capability (IFR)</c> character.
    /// </summary>
    /// <remarks>See section 5.108.</remarks>
    [Character(31), Transform<BoolConverter>]
    public bool IsProcedurePublished { get; set; }

    /// <inheritdoc cref="Terms.RunwaySurfaceType"/>
    [Character(32), Transform<RunwaySurfaceTypeConverter>]
    public Terms.RunwaySurfaceType LongestRunwayType { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='MagneticVariation']/*"/>
    [Field(52, 56), Decode<MagneticVariationConverter>]
    public float MagneticVariation { get; set; }

    /// <summary>
    /// <c>Airport Elevation (ELEV)</c> field.
    /// </summary>
    /// <value>Feet.</value>
    /// <remarks>See section 5.55.</remarks>
    [Field(57, 61), Decode<IntConverter>]
    public int Elevation { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='SpeedLimit']/*"/>
    [Field(62, 64), Decode<IntConverter>]
    public int SpeedLimit { get; set; }

    /// <summary>
    /// <c>Recommended NAVAID (RECD NAV)</c> and <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See section 5.23 and 5.14.</remarks>
    [Foreign(65, 68), Foreign(69, 70)]
    public OmnidirectionalStation? RecommendedStation { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='TransitionAltitude']/*"/>
    [Field(71, 75), Decode<IntConverter>]
    public int TransitionAltitude { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='TransitionLevel']/*"/>
    [Field(76, 80), Decode<IntConverter>]
    public int TransitionLevel { get; set; }

    /// <inheritdoc cref="Terms.PortPrivacy"/>
    [Character(81), Transform<PortPrivacyConverter>]
    public Terms.PortPrivacy Privacy { get; set; }

    /// <summary>
    /// <c>Time Zone</c> field.
    /// </summary>
    /// <remarks>See section 5.178.</remarks>
    [Field(82, 84)]
    public string? TimeZone { get; set; }

    /// <summary>
    /// <c>Daylight Time Indicator (DAY TIME)</c> character.
    /// </summary>
    /// <remarks>See section 5.179.</remarks>
    [Character(85), Transform<BoolConverter>]
    public bool IsDaylightTime { get; set; }

    /// <inheritdoc cref="Arinc424.CourseType"/>
    [Character(86), Transform<CourseTypeConverter>]
    public CourseType CourseType { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Datum']/*"/>
    [Field(87, 89)]
    public string? Datum { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Name']/*"/>
    [Field(94, 123)]
    public string? Name { get; set; }

    /// <summary>
    /// Associated gates.
    /// </summary>
    [Many]
    public List<Gate> Gates { get; set; } = [];

    /// <summary>
    /// Associated runways.
    /// </summary>
    [Many]
    public List<Runway> Runways { get; set; } = [];

    /// <summary>
    /// Associated GLS's.
    /// </summary>
    [Many]
    public List<GlobalLandingSystem> GlobalLandingSystems { get; set; } = [];

    /// <summary>
    /// Associated MLS's.
    /// </summary>
    [Many]
    public List<MicrowaveLandingSystem> MicrowaveLandingSystems { get; set; } = [];

    /// <summary>
    /// Associated ILS's.
    /// </summary>
    [Many]
    public List<InstrumentLandingSystem> InstrumentLandingSystems { get; set; } = [];

    /// <summary>
    /// Associated Approach Procedures.
    /// </summary>
    [Many]
    public List<AirportApproach> Approaches { get; set; } = [];

    /// <summary>
    /// Associated STARs.
    /// </summary>
    [Many]
    public List<AirportArrival> Arrivals { get; set; } = [];

    /// <summary>
    /// Associated SIDs.
    /// </summary>
    [Many]
    public List<AirportDeparture> Departures { get; set; } = [];

    /// <summary>
    /// Associated Terminal Waypoints.
    /// </summary>
    [Many]
    public List<AirportTerminalWaypoint> TerminalWaypoints { get; set; } = [];

    /// <summary>
    /// Associated NDBs.
    /// </summary>
    [Many]
    public List<AirportBeacon> Beacons { get; set; } = [];

    /// <summary>
    /// Associated VHF Navaids.
    /// </summary>
    [Many]
    public List<OmnidirectionalStation> OmnidirectionalStations { get; set; } = [];
}
