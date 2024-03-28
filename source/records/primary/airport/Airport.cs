using System.Diagnostics;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Terms;
using Arinc.Spec424.Converters;

namespace Arinc.Spec424.Records;

#pragma warning disable CS8618

/// <summary>
/// <c>Airport</c> primary record.
/// </summary>
/// <remarks>See section 4.1.7.1.</remarks>
[Record('P', 'A', subsectionIndex: 13), Continuous]
[DebuggerDisplay($"{{{nameof(Identifier)}}}, {{{nameof(Name)}}}")]
public class Airport : Geo, IIcao, IIdentity
{
    /// <summary>
    /// <c>Airport Identifier (ARPT IDENT)</c> field.
    /// </summary>
    /// <remarks>See section 5.6.</remarks>
    [Field(7, 10), Primary]
    public string Identifier { get; init; }

    [Field(11, 12), Primary]
    public string IcaoCode { get; init; }

    /// <summary>
    /// <c>ATA/IATA Designator (ATA/IATA)</c> field.
    /// </summary>
    /// <remarks>See section 5.107.</remarks>
    [Field(14, 16)]
    public string? Designator { get; init; }

    /// <summary>
    /// <c>Speed Limit Altitude</c> field.
    /// </summary>
    /// <remarks>See section 5.73.</remarks>
    [Field(23, 27), Decode<AltitudeConverter>]
    public (int Altitude, AltitudeUnit Unit) Limit { get; init; }

    /// <summary>
    /// <c>Longest Runway (LONGEST RWY)</c> field.
    /// </summary>
    /// <value>Hundreds of feet.</value>
    /// <remarks>See section 5.54.</remarks>
    [Field(28, 30), Decode<NumericConverter>]
    public int LongestRunwayLength { get; init; }

    /// <summary>
    /// <c>IFR Capability (IFR)</c> character.
    /// </summary>
    /// <remarks>See section 5.108.</remarks>
    [Character(31), Transform<BoolConverter>]
    public bool IsProcedurePublished { get; init; }

    /// <inheritdoc cref="RunwaySurfaceType"/>
    [Character(32), Transform<RunwaySurfaceTypeConverter>]
    public RunwaySurfaceType LongestRunwayType { get; init; }

    /// <include file='Comments.xml' path="doc/member[@name='MagneticVariation']/*"/>
    [Field(52, 56), Decode<MagneticVariationConverter>]
    public float MagneticVariation { get; init; }

    /// <summary>
    /// <c>Airport Elevation (ELEV)</c> field.
    /// </summary>
    /// <value>Feet.</value>
    /// <remarks>See section 5.55.</remarks>
    [Field(57, 61), Decode<NumericConverter>]
    public int Elevation { get; init; }

    /// <include file='Comments.xml' path="doc/member[@name='SpeedLimit']/*"/>
    [Field(62, 64), Decode<NumericConverter>]
    public int SpeedLimit { get; init; }

    /// <summary>
    /// <c>Recommended NAVAID (RECD NAV)</c> and <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See section 5.23 and 5.14.</remarks>
    [Foreign(65, 68), Foreign(69, 70)]
    public OmnidirectionalStation? RecommendedStation { get; init; }

    /// <include file='Comments.xml' path="doc/member[@name='TransitionAltitude']/*"/>
    [Field(71, 75), Decode<NumericConverter>]
    public int TransitionAltitude { get; init; }

    /// <include file='Comments.xml' path="doc/member[@name='TransitionLevel']/*"/>
    [Field(76, 80)]
    public string? TransitionLevel { get; init; }

    /// <inheritdoc cref="PortPrivacy"/>
    [Character(81), Transform<PortPrivacyConverter>]
    public PortPrivacy Privacy { get; init; }

    /// <summary>
    /// <c>Time Zone</c> field.
    /// </summary>
    /// <remarks>See section 5.178.</remarks>
    [Field(82, 84)]
    public string TimeZone { get; init; }

    /// <summary>
    /// <c>Daylight Time Indicator (DAY TIME)</c> character.
    /// </summary>
    /// <remarks>See section 5.179.</remarks>
    [Character(85), Transform<BoolConverter>]
    public bool IsDaylightTime { get; init; }

    /// <inheritdoc cref="Terms.CourseType"/>
    [Character(86), Transform<CourseTypeConverter>]
    public CourseType CourseType { get; init; }

    /// <summary>
    /// <c>Datum Code (DATUM)</c> field.
    /// </summary>
    /// <remarks>See section 5.197.</remarks>
    [Field(87, 89)]
    public string DatumCode { get; init; }

    /// <summary>
    /// <c>Name</c> field.
    /// </summary>
    /// <remarks>See section 5.71.</remarks>
    [Field(94, 123)]
    public string Name { get; init; }

    [Many]
    public List<Runway> Runways { get; init; } = [];

    [Many]
    public List<AirportApproach> Approaches { get; init; } = [];

    [Many]
    public List<AirportTerminalArrival> Arrivals { get; init; } = [];

    [Many]
    public List<AirportInstrumentDeparture> Departures { get; init; } = [];

    [Many]
    public List<AirportTerminalWaypoint> TerminalWaypoints { get; init; } = [];

    [Many]
    public List<AirportBeacon> Beacons { get; init; } = [];

    [Many]
    public List<OmnidirectionalStation> OmnidirectionalStations { get; init; } = [];
}
