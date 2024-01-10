using System.Diagnostics;

using Arinc.Spec424.Attributes;

namespace Arinc.Spec424.Records.Subsequences;

#pragma warning disable CS8618

/// <summary>
/// Subsequence used by <see cref="Airway"/>
/// </summary>
[DebuggerDisplay("Fix - {FixIdentifier}")]
public class AirwayPoint : Record424
{
    /// <summary>
    /// <c>Fix Identifier (FIX IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.13</remarks>
    [Field(30, 34)]
    public string FixIdentifier { get; init; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.14</remarks>
    [Field(35, 36)]
    public string FixIcaoCode { get; init; }

    /// <summary>
    /// <c>Section code</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.4</remarks>
    [Character(37)]
    public char FixSectionCode { get; init; }

    /// <summary>
    /// <c>Subsection Code (SUB CODE)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.5</remarks>
    [Character(38)]
    public char FixSubsectionCode { get; init; }

    /// <summary>
    /// <c>Waypoint Description Code (DESC CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.17</remarks>
    [Field(40, 43)]
    public string WaypointDescriptionCode { get; init; }

    /// <summary>
    /// <c>Boundary Code (BDY CODE)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.18</remarks>
    [Character(44)]
    public char BoundaryCode { get; init; }

    /// <summary>
    /// <c>Route Type (RT TYPE)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.7</remarks>
    [Character(45)]
    public char RouteType { get; init; }

    /// <summary>
    /// <c>Level (LEVEL)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.19</remarks>
    [Character(46)]
    public char Level { get; init; }

    /// <summary>
    /// <c>Directional Restriction</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.115</remarks>
    [Character(47)]
    public char DirectionRestriction { get; init; }

    /// <summary>
    /// <c>Cruise Table Identifier (CRSE TBL IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.134</remarks>
    [Field(48, 49)]
    public string CruiseTableIndicator { get; init; }

    /// <summary>
    /// <c>EU Indicator (EU IND)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.164</remarks>
    [Character(50)]
    public char EuIndicator { get; init; }

    /// <summary>
    /// <c>Recommended NAVAID (RECD NAV)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.23</remarks>
    [Field(51, 54)]
    public string? RecommendedNavaid { get; init; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.14</remarks>
    [Field(55, 56)]
    public string RecommendedNavaidIcaoCode { get; init; }

    /// <summary>
    /// <c>Required Navigation Performance (RNP)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.211</remarks>
    [Field(57, 59)]
    public string RequiredNavigationPerformance { get; init; }

    /// <summary>
    /// <c>Theta (THETA)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.24</remarks>
    [Field(63, 66)]
    public string? Theta { get; init; }

    /// <summary>
    /// <c>Rho (RHO)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.25</remarks>
    [Field(67, 70)]
    public string? Rho { get; init; }

    /// <summary>
    /// <c>Outbound Magnetic Course (OB MAG CRS)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.26</remarks>
    [Field(71, 74)]
    public string OutboundMagneticCourse { get; init; }

    /// <summary>
    /// <c>Route Distance From (RTE DIST FROM)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.27</remarks>
    [Field(75, 78)]
    public string RouteDistanceFrom { get; init; }

    /// <summary>
    /// <c>Inbound Magnetic Course (IB MAG CRS)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.28</remarks>
    [Field(79, 82)]
    public string InboundMagneticCourse { get; init; }

    /// <summary>
    /// <c>Minimum Altitude</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.30</remarks>
    [Field(84, 88)]
    public string MinimumAltitude1 { get; init; }

    /// <summary>
    /// <c>Minimum Altitude</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.30</remarks>
    [Field(89, 93)]
    public string? MinimumAltitude2 { get; init; }

    /// <summary>
    /// <c>Maximum Altitude (MAX ALT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.127</remarks>
    [Field(94, 98)]
    public string MaximumAltitude { get; init; }

    /// <summary>
    /// <c>Fixed Radius Transition Indicator (FIXED RAD IND)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.254</remarks>
    [Field(99, 101)]
    public string? FixRadiusTransitionIndicator { get; init; }

    /// <summary>
    /// <c>Vertical Scale Factor (VSF)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.293</remarks>
    [Field(102, 104)]
    public string? VerticalScaleFactor { get; init; }

    /// <summary>
    /// <c>RVSM Minimum Level</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.294</remarks>
    [Field(105, 107)]
    public string? RvsmMinimumLevel { get; init; }

    /// <summary>
    /// <c>RVSM Maximum Level</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.295</remarks>
    [Field(108, 110)]
    public string? VsfRvsmMaximumLevel { get; init; }
}
