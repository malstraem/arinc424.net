namespace Arinc424.Ground;

using Comms;
using Waypoints;
using Navigation;
using Procedures;

[Known(7, 10), Icao(11, 12), Continuous]

[DebuggerDisplay($"{{{nameof(Identifier)},nq}}, {nameof(Name)} - {{{nameof(Name)},nq}}")]
public abstract class Port : Fix, INamed
{
    /**<summary>
    <c>ATA/IATA Designator (ATA/IATA)</c> field.
    </summary>
    <remarks>See section 5.107.</remarks>*/
    [Field(14, 16)]
    public string? Designator { get; set; }

    /**<summary>
    <c>Speed Limit Altitude</c> field.
    </summary>
    <remarks>See section 5.73.</remarks>*/
    [Field(23, 27)]
    public Altitude Limit { get; set; }

    /**<summary>
    <c>IFR Capability (IFR)</c> character.
    </summary>
    <remarks>See section 5.108.</remarks>*/
    [Character(31)]
    public Bool IsProcedurePublished { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='MagneticVariation']/*"/>
    [Field(52, 56), Variation]
    public float Variation { get; set; }

    /**<summary>
    <c>Airport/Heliport Elevation (ELEV)</c> field.
    </summary>
    <value>Feet.</value>
    <remarks>See section 5.55.</remarks>*/
    [Field(57, 61), Integer]
    public int Elevation { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='SpeedLimit']/*"/>
    [Field(62, 64), Integer]
    public int SpeedLimit { get; set; }

    /// <summary><c>Recommended NAVAID (RECD NAV)</c> field.</summary>
    [Known(65, 68), Icao(69, 70)]
    public Omnidirect? Recommended { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Transition']/*"/>
    [Field(71, 75), Integer]
    public int? TransitionAltitude { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Transition']/*"/>
    [Field(76, 80), Integer]
    public int? TransitionLevel { get; set; }

    /// <inheritdoc cref="Arinc424.Privacy"/>
    [Character(81)]
    public Privacy Privacy { get; set; }

    /// <summary><c>Time Zone</c> field.</summary>
    /// <remarks>See section 5.178.</remarks>
    [Field(82, 84)]
    public string? TimeZone { get; set; }

    /**<summary>
    <c>Daylight Time Indicator (DAY TIME)</c> character.
    </summary>
    <remarks>See section 5.179.</remarks>*/
    [Character(85)]
    public Bool IsDaylightTime { get; set; }

    /// <inheritdoc cref="Arinc424.CourseType"/>
    [Character(86), Character<Heliport>(92)]
    public CourseType CourseType { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Datum']/*"/>
    [Field(87, 89), Field<Heliport>(28, 30)]
    public string? Datum { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Name']/*"/>
    [Field(94, 123)]
    public string? Name { get; set; }

    /// <summary>Associated GBAS points.</summary>
    [Many]
    public GroundPoint[]? GroundPoints { get; set; }

    /// <summary>Associated SBAS points.</summary>
    [Many]
    public SatellitePoint[]? SatellitePoints { get; set; }

    /// <summary>Associated STARs.</summary>
    [Many]
    public Arrival[]? Arrivals { get; set; }

    /// <summary>Associated Approach Procedures.</summary>
    [Many]
    public Approach[]? Approaches { get; set; }

    /// <summary>Associated SIDs.</summary>
    [Many]
    public Departure[]? Departures { get; set; }

    /// <summary>Associated Communications.</summary>
    [Many]
    public PortCommunication[]? Communications { get; set; }

    /// <summary>Associated TAAs.</summary>
    [Many]
    public ArrivalAltitude[]? ArrivalAltitudes { get; set; }

    /// <summary>Associated MSAs.</summary>
    [Many]
    public MinimumAltitude[]? MinimumAltitudes { get; set; }

    /// <summary>Associated Terminal Waypoints.</summary>
    [Many]
    public TerminalWaypoint[]? Waypoints { get; set; }
}
