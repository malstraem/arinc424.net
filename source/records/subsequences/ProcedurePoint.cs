using System.Diagnostics;

using Arinc.Spec424.Attributes;

namespace Arinc.Spec424.Records.Subsequences;

#pragma warning disable CS8618

/// <summary>
/// Combination of procedure point properties used by
/// <see cref="AirportApproach"/>, <see cref="StandardInstrumentDeparture"/> and <see cref="StandardTerminalArrival"/> like subsequence.
/// </summary>
[DebuggerDisplay("Fix - {FixIdentifier}")]
public class ProcedurePoint : Record424
{
    /// <summary>
    /// <c>Fix Identifier (FIX IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.13.</remarks>
    [Field(30, 34)]
    public string FixIdentifier { get; init; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.14.</remarks>
    [Field(35, 36)]
    public string FixIcaoCode { get; init; }

    /// <summary>
    /// <c>Section Code (SEC CODE)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.4.</remarks>
    [Character(37)]
    public char FixSectionCode { get; init; }

    /// <summary>
    /// <c>Subsection Code (SUB CODE)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.5.</remarks>
    [Character(38)]
    public char FixSubsectionCode { get; init; }

    /// <summary>
    /// <c>Waypoint Description Code (DESC CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.17.</remarks>
    [Field(40, 43)]
    public string WaypointDescriptionCode { get; init; }

    /// <summary>
    /// <c>Turn Direction (TURN DIR)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.20.</remarks>
    [Character(44)]
    public char TumDirection { get; init; }

    /// <summary>
    /// <c>Required Navigation Performance</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.211.</remarks>
    [Field(45, 47)]
    public string RNP { get; init; }

    /// <summary>
    /// <c>Path and Termination (PATH TERM)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.21.</remarks>
    [Field(48, 49)]
    public string PathAndTermination { get; init; }

    /// <summary>
    /// <c>Turn Direction Valid (TDV)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.22.</remarks>
    [Character(50)]
    public char TurnDirectionValid { get; init; }

    /// <summary>
    /// <c>Recommended NAVAID (RECD NAV)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.23.</remarks>
    [Field(51, 54)]
    public string RecommendedNavaid { get; init; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.14.</remarks>
    [Field(55, 56)]
    public string NavaidIcaoCode { get; init; }

    /// <summary>
    /// <c>ARC Radius (ARC RAD)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.204.</remarks>
    [Field(57, 62)]
    public string? ArcRadius { get; init; }

    /// <summary>
    /// <c>Theta (THETA)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.24.</remarks>
    [Field(63, 66)]
    public string? Theta { get; init; }

    /// <summary>
    /// <c>Rho (RHO)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.25.</remarks>
    [Field(67, 70)]
    public string? Rho { get; init; }

    /// <summary>
    /// <c>Outbound Magnetic Course (OB MAG CRS)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.26.</remarks>
    [Field(71, 74)]
    public string MagneticCourse { get; init; }

    /// <summary>
    /// <c>Route Distance From, Holding Distance/Time (RTE DIST FROM, HOLD DIST/TIME)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.27.</remarks>
    [Field(75, 78)]
    public string? RouteDistanceOrHoldingTime { get; init; }

    /// <summary>
    /// <c>Section Code (SEC CODE)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.4.</remarks>
    [Character(79)]
    public char? RecdNavSection { get; init; }

    /// <summary>
    /// <c>Subsection code (SUB CODE)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.5.</remarks>
    [Character(80)]
    public char? RecdNavSubsection { get; init; }

    /// <summary>
    /// <c>Holding Pattern/Race Track Course Reversal Leg Inbound/Outbound Indicator</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.298.</remarks>
    [Character(81)]
    public char LegDirectionIndicator { get; init; }

    /// <summary>
    /// <c>Altitude Description (ALT DESC)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.29.</remarks>
    [Character(83)]
    public char AltitudeDescription { get; init; }

    /// <summary>
    /// <c>ATC Indicator (ATC)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.81.</remarks>
    [Character(84)]
    public char IndicatorATC { get; init; }

    /// <summary>
    /// <c>Altitude/Minimum Altitude</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.30.</remarks>
    [Field(85, 89)]
    public string Altitude1 { get; init; }

    /// <summary>
    /// <c>Altitude/Minimum Altitude</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.30.</remarks>
    [Field(90, 94)]
    public string Altitude2 { get; init; }

    /// <summary>
    /// <c>Transition Altitude/Level (TRANS ALTITUDE/LEVEL)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.53.</remarks>
    [Field(95, 99)]
    public string TransitionAltitude { get; init; }

    /// <summary>
    /// <c>Speed Limit (SPEED LIMIT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.72.</remarks>
    [Field(100, 102)]
    public string SpeedLimit { get; init; }

    /// <summary>
    /// <c>Vertical Angle (VERT ANGLE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.70.</remarks>
    [Field(103, 106)]
    public string VerticalAngel { get; init; }

    /// <summary>
    /// <c>Center Fix (CENTER FIX)
    /// Procedure Turn (PROC TURN)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.144 or 5.271.</remarks>
    [Field(107, 111)]
    public string FixProcedureIndicator { get; init; }

    /// <summary>
    /// <c>Multiple Code (MULTI CD)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.130 or 5.271 .</remarks>
    [Character(112)]
    public char? CodeTaaIndicator { get; init; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.14.</remarks>
    [Field(113, 114)]
    public string? FixProcedureIcaoCode { get; init; }

    /// <summary>
    /// <c>Section Code (SEC CODE)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.4.</remarks>
    [Character(115)]
    public char? FixProcedureSectionCode { get; init; }

    /// <summary>
    /// <c>Subsection Code (SUB CODE)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.5.</remarks>
    [Character(116)]
    public char? FixProcedureSubsectionCode { get; init; }

    /// <summary>
    /// <c>GNSS/FMS Indicator (GNSS/FMS IND)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.222.</remarks>
    [Character(117)]
    public char GnssFmsIndication { get; init; }

    /// <summary>
    /// <c>Speed Limit Description (SLD)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.261.</remarks>
    [Character(118)]
    public char SpeedLimitDescription { get; init; }

    /// <summary>
    /// <c>Route Type (RT TYPE)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.7.</remarks>
    [Character(119)]
    public char RouteQualifier1 { get; init; }

    /// <summary>
    /// <c>Route Type (RT TYPE)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.7.</remarks>
    [Character(120)]
    public char RouteQualifier2 { get; init; }
}
