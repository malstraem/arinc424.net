using System.Diagnostics;

using Arinc424.Attributes;
using Arinc424.Converters;
using Arinc424.Navigation;
using Arinc424.Ports;
using Arinc424.Waypoints;
using Arinc424.Waypoints.Terms;

namespace Arinc424.Procedures;

/// <summary>
/// Fields of <c>SID/STAR/Approach</c> primary record. Used by <see cref="AirportApproach"/>, <see cref="AirportDeparture"/>
/// and <see cref="AirportArrival"/> like subsequence.
/// </summary>
[DebuggerDisplay($"Fix - {{{nameof(Fix)}}}")]
public abstract class ProcedurePoint : Record424
{
    [Type(37, 38)]
    [Foreign<Runway, AirportTerminalWaypoint, AirportBeacon>(7, 12), Foreign(30, 36)]
    public Geo? Fix { get; set; }

    /// <inheritdoc cref="WaypointDescriptions"/>
    [Field(40, 43), Decode<WaypointDescriptionsConverter>]
    public WaypointDescriptions Descriptions { get; set; }

    /// <inheritdoc cref="Arinc424.Turn"/>
    [Character(44), Transform<TurnConverter>]
    public Turn Turn { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='RNP']/*"/>
    [Field(45, 47), Decode<NavigationPerformanceConverter>]
    public float NavigationPerformance { get; set; }

    /// <inheritdoc cref="Terms.LegType"/>
    [Field(48, 49), Decode<LegTypeConverter>]
    public Terms.LegType LegType { get; set; }

    /// <summary>
    /// <c>Turn Direction Valid (TDV)</c> character.
    /// </summary>
    /// <remarks>See section 5.22.</remarks>
    [Character(50), Transform<BoolConverter>]
    public bool IsTurnRequired { get; set; }

    [Obsolete("TODO abstract navaid instead of geo point")]
    [Type(79, 80)]
    [Foreign<AirportBeacon>(7, 12), Foreign(51, 56)]
    public Navaid? RecommendedNavaid { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='ArcRadius']/*"/>
    [Field(57, 62), Decode<ThousandsConverter>]
    public float ArcRadius { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Theta']/*"/>
    [Field(63, 66), Decode<TenthsConverter>]
    public float Theta { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Rho']/*"/>
    [Field(67, 70), Decode<TenthsConverter>]
    public float Rho { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='OutboundMagneticCourse']/*"/>
    [Field(71, 74), Decode<CourseConverter>]
    public Course Course { get; set; }

    /// <summary>
    /// <c>Route Distance From, Holding Distance/Time (RTE DIST FROM, HOLD DIST/TIME)</c> field.
    /// </summary>
    /// <remarks>See section 5.27.</remarks>
    [Field(75, 78)]
    public string? DistanceTiming { get; set; }

    /// <inheritdoc cref="LegDirection"/>
    [Character(81), Transform<LegDirectionConverter>]
    public LegDirection Direction { get; set; }

    /// <inheritdoc cref="Arinc424.AltitudeDescription"/>
    [Character(83), Transform<AltitudeDescriptionConverter>]
    public AltitudeDescription AltitudeDescription { get; set; }

    /// <summary>
    /// <c>ATC Indicator (ATC)</c> character.
    /// </summary>
    /// <remarks>See section 5.81.</remarks>
    [Character(84)]
    public char AtcIndicator { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Altitude']/*"/>
    [Field(85, 89), Decode<AltitudeConverter>]
    public Altitude Altitude { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Altitude']/*"/>
    [Field(90, 94), Decode<AltitudeConverter>]
    public Altitude Altitude2 { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='TransitionAltitude']/*"/>
    [Field(95, 99), Decode<IntConverter>]
    public int TransitionAltitude { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='SpeedLimit']/*"/>
    [Field(100, 102), Decode<IntConverter>]
    public int SpeedLimit { get; set; }

    /// <summary>
    /// <c>Center Fix (CENTER FIX)</c>.
    /// </summary>
    /// <remarks>See section 5.144.</remarks>
    [Type(115, 116)]
    [Foreign<Runway, AirportTerminalWaypoint, AirportBeacon>(7, 12), Foreign(107, 111), Foreign(113, 114)]
    public Geo? CenterFix { get; set; }

    /// <summary>
    /// <c>Multiple Code (MULTI CD)</c> or <c>Procedure Turn Indicator</c> character.
    /// </summary>
    /// <remarks>See section 5.130 or 5.271.</remarks>
    [Character(112)]
    public char CodeTaaIndicator { get; set; }

    /// <inheritdoc cref="Terms.Overlay"/>
    [Character(117), Transform<OverlayConverter>]
    public Terms.Overlay Overlay { get; set; }

    /// <inheritdoc cref="Terms.SpeedLimitType"/>
    [Character(118), Transform<SpeedLimitTypeConverter>]
    public Terms.SpeedLimitType SpeedLimitType { get; set; }
}
