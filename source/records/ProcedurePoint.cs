using System.Diagnostics;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Converters;
using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Records;

#pragma warning disable CS8618

/// <summary>
/// Combination of procedure point properties used by
/// <see cref="AirportApproach"/>, <see cref="AirportDeparture"/> and <see cref="AirportArrival"/> like subsequence.
/// </summary>
[DebuggerDisplay($"Fix - {{{nameof(Fix)}}}")]
public class ProcedurePoint : Record424
{
    [Type(37, 38)]
    [Foreign<Runway, AirportTerminalWaypoint, AirportBeacon>(7, 12), Foreign(30, 34), Foreign(35, 36)]
    public Geo? Fix { get; init; }

    /// <inheritdoc cref="WaypointDescriptions"/>
    [Field(40, 43), Decode<WaypointDescriptionsConverter>]
    public WaypointDescriptions Descriptions { get; init; }

    /// <inheritdoc cref="Terms.TurnDirection"/>
    [Character(44), Transform<TurnDirectionConverter>]
    public TurnDirection TurnDirection { get; init; }

    /// <include file='Comments.xml' path="doc/member[@name='RNP']/*"/>
    [Field(45, 47), Decode<NavigationPerformanceConverter>]
    public float NavigationPerformance { get; init; }

    /// <inheritdoc cref="Terms.LegType"/>
    [Field(48, 49), Decode<LegTypeConverter>]
    public LegType LegType { get; init; }

    /// <summary>
    /// <c>Turn Direction Valid (TDV)</c> character.
    /// </summary>
    /// <remarks>See section 5.22.</remarks>
    [Character(50), Transform<BoolConverter>]
    public bool IsTurnRequired { get; init; }

    [Obsolete("TODO abstract navaid instead of geo point")]
    [Type(79, 80)]
    [Foreign(51, 54), Foreign(55, 56)]
    public Geo? RecommendedNavaid { get; init; }

    /// <summary>
    /// <c>ARC Radius (ARC RAD)</c> field.
    /// </summary>
    /// <remarks>See section 5.204.</remarks>
    [Field(57, 62)]
    public string? ArcRadius { get; init; }

    /// <include file='Comments.xml' path="doc/member[@name='Theta']/*"/>
    [Field(63, 66), Decode<TenthsConverter>]
    public float Theta { get; init; }

    /// <include file='Comments.xml' path="doc/member[@name='Rho']/*"/>
    [Field(67, 70), Decode<TenthsConverter>]
    public float Rho { get; init; }

    /// <include file='Comments.xml' path="doc/member[@name='OutboundMagneticCourse']/*"/>
    [Field(71, 74), Decode<CourseConverter>]
    public (float Value, CourseType Type) Course { get; init; }

    /// <summary>
    /// <c>Route Distance From, Holding Distance/Time (RTE DIST FROM, HOLD DIST/TIME)</c> field.
    /// </summary>
    /// <remarks>See section 5.27.</remarks>
    [Field(75, 78)]
    public string? DistanceTiming { get; init; }

    /// <inheritdoc cref="LegDirection"/>
    [Character(81), Transform<LegDirectionConverter>]
    public LegDirection Direction { get; init; }

    /// <summary>
    /// <c>Altitude Description (ALT DESC)</c> character.
    /// </summary>
    /// <remarks>See section 5.29.</remarks>
    [Character(83)]
    public char AltitudeDescription { get; init; }

    /// <summary>
    /// <c>ATC Indicator (ATC)</c> character.
    /// </summary>
    /// <remarks>See section 5.81.</remarks>
    [Character(84)]
    public char IndicatorAtc { get; init; }

    /// <include file='Comments.xml' path="doc/member[@name='Altitude']/*"/>
    [Field(85, 89), Decode<AltitudeConverter>]
    public (int Altitude, AltitudeUnit Unit) Altitude { get; init; }

    /// <include file='Comments.xml' path="doc/member[@name='Altitude']/*"/>
    [Field(90, 94), Decode<AltitudeConverter>]
    public (int Altitude, AltitudeUnit Unit) Altitude2 { get; init; }

    /// <summary>
    /// <c>Transition Altitude/Level (TRANS ALTITUDE/LEVEL)</c> field.
    /// </summary>
    /// <remarks>See section 5.53.</remarks>
    [Field(95, 99)]
    public string TransitionAltitude { get; init; }

    /// <summary>
    /// <c>Speed Limit (SPEED LIMIT)</c> field.
    /// </summary>
    /// <remarks>See section 5.72.</remarks>
    [Field(100, 102)]
    public string SpeedLimit { get; init; }

    /// <summary>
    /// <c>Vertical Angle (VERT ANGLE)</c> field.
    /// </summary>
    /// <remarks>See section 5.70.</remarks>
    [Field(103, 106)]
    public string VerticalAngel { get; init; }

    /// <summary>
    /// <c>Center Fix (CENTER FIX)
    /// Procedure Turn (PROC TURN)</c> field.
    /// </summary>
    /// <remarks>See section 5.144 or 5.271.</remarks>
    [Field(107, 111)]
    public string FixProcedureIndicator { get; init; }

    /// <summary>
    /// <c>Multiple Code (MULTI CD)</c> character.
    /// </summary>
    /// <remarks>See section 5.130 or 5.271 .</remarks>
    [Character(112)]
    public char? CodeTaaIndicator { get; init; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See section 5.14.</remarks>
    [Field(113, 114)]
    public string? FixProcedureIcaoCode { get; init; }

    /// <summary>
    /// <c>Section Code (SEC CODE)</c> character.
    /// </summary>
    /// <remarks>See section 5.4.</remarks>
    [Character(115)]
    public char? FixProcedureSectionCode { get; init; }

    /// <summary>
    /// <c>Subsection Code (SUB CODE)</c> character.
    /// </summary>
    /// <remarks>See section 5.5.</remarks>
    [Character(116)]
    public char? FixProcedureSubsectionCode { get; init; }

    /// <summary>
    /// <c>GNSS/FMS Indicator (GNSS/FMS IND)</c> character.
    /// </summary>
    /// <remarks>See section 5.222.</remarks>
    [Character(117)]
    public char GnssFmsIndication { get; init; }

    /// <summary>
    /// <c>Speed Limit Description (SLD)</c> character.
    /// </summary>
    /// <remarks>See section 5.261.</remarks>
    [Character(118)]
    public char SpeedLimitDescription { get; init; }
}
