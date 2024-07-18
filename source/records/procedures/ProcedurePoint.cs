using Arinc424.Ports;
using Arinc424.Waypoints.Terms;

namespace Arinc424.Procedures;

/// <summary>
/// Fields of <c>Airport</c> and <c>Heliport SID/STAR/Approach</c>.
/// </summary>
[Port(7, 10)]
[DebuggerDisplay($"{nameof(Fix)} - {{{nameof(Fix)}}}")]
public abstract class ProcedurePoint : Record424
{
    [Type(37, 38)]
    [Identifier(30, 34), Icao(35, 36)]
    public Fix? Fix { get; set; }

    /// <inheritdoc cref="WaypointDescriptions"/>
    [Field(40, 43)]
    public WaypointDescriptions Descriptions { get; set; }

    /// <inheritdoc cref="Arinc424.Turn"/>
    [Character(44)]
    public Turn Turn { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='RNP']/*"/>
    [Field(45, 47), Performance]
    public float Performance { get; set; }

    /// <inheritdoc cref="Terms.LegType"/>
    [Field(48, 49)]
    public Terms.LegType LegType { get; set; }

    /// <summary>
    /// <c>Turn Direction Valid (TDV)</c> character.
    /// </summary>
    /// <remarks>See section 5.22.</remarks>
    [Character(50)]
    public Bool IsTurnRequired { get; set; }

    [Type(79, 80)]
    [Identifier(51, 54), Icao(55, 56)]
    public Fix? Recommended { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='ArcRadius']/*"/>
    [Field(57, 62), Float(1000)]
    public float ArcRadius { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Theta']/*"/>
    [Field(63, 66), Float(10)]
    public float Theta { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Rho']/*"/>
    [Field(67, 70), Float(10)]
    public float Rho { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='OutboundMagneticCourse']/*"/>
    [Field(71, 74)]
    public Course Course { get; set; }

    /// <summary>
    /// <c>Route Distance From, Holding Distance/Time (RTE DIST FROM, HOLD DIST/TIME)</c> field.
    /// </summary>
    /// <remarks>See section 5.27.</remarks>
    [Field(75, 78)]
    public string? DistanceTiming { get; set; }

    /// <inheritdoc cref="LegDirection"/>
    [Character(81)]
    public LegDirection Direction { get; set; }

    /// <inheritdoc cref="Arinc424.AltitudeDescription"/>
    [Character(83)]
    public AltitudeDescription AltitudeDescription { get; set; }

    /// <summary>
    /// <c>ATC Indicator (ATC)</c> character.
    /// </summary>
    /// <remarks>See section 5.81.</remarks>
    [Character(84)]
    public char AtcIndicator { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Altitude']/*"/>
    [Field(85, 89)]
    public Altitude Altitude { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Altitude']/*"/>
    [Field(90, 94)]
    public Altitude Altitude2 { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='TransitionAltitude']/*"/>
    [Field(95, 99), Integer]
    public int TransitionAltitude { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='SpeedLimit']/*"/>
    [Field(100, 102), Integer]
    public int SpeedLimit { get; set; }

    /// <summary>
    /// <c>Center Fix (CENTER FIX)</c> or <c>TAA Sector Identifier</c> field.
    /// </summary>
    /// <remarks>See section 5.144 and 5.272.</remarks>
    /*[Type(115, 116)]
    [ForeignExcept<Airport, Omnidirectional, Nondirectional, EnrouteWaypoint>(7, 12)]
    [Foreign(107, 111), Foreign(113, 114)]*/
    [Field(107, 111)]
    [Obsolete("todo: spec contains error, need more analysis")]
    public string? Center { get; set; }

    /// <summary>
    /// <c>Multiple Code (MULTI CD)</c> or <c>Procedure Turn Indicator</c> character.
    /// </summary>
    /// <remarks>See section 5.130 or 5.271.</remarks>
    [Character(112), Obsolete("same")]
    public char CodeTurnIndicator { get; set; }

    /// <inheritdoc cref="Terms.Overlay"/>
    [Character(117)]
    public Terms.Overlay Overlay { get; set; }

    /// <inheritdoc cref="Terms.SpeedLimitType"/>
    [Character(118)]
    public Terms.SpeedLimitType SpeedLimitType { get; set; }
}
