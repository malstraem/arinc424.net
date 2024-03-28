using System.Diagnostics;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Terms;
using Arinc.Spec424.Converters;

namespace Arinc.Spec424.Records.Sub;

#pragma warning disable CS8618

/// <summary>
/// Fields of <c>Enroute Airways</c> primary record. Used by <see cref="Airway"/> like subsequence.
/// </summary>
/// <remarks>See section 4.1.6.1.</remarks>
[DebuggerDisplay($"Fix - {{{nameof(Fix)}}}")]
public class AirwayPoint : Record424
{
    [Type(37, 38)]
    [Foreign(30, 34)]
    [Foreign(35, 36)]
    public Geo Fix { get; init; }

    /// <inheritdoc cref="WaypointDescriptions"/>
    [Field(40, 43), Decode<WaypointDescriptionsConverter>]
    public WaypointDescriptions Descriptions { get; init; }

    /// <inheritdoc cref="Terms.BoundaryCode"/>
    [Character(44), Transform<BoundaryCodeConverter>]
    public BoundaryCode BoundaryCode { get; init; }

    /// <inheritdoc cref="AirwayType"/>
    [Character(45), Transform<AirwayTypeConverter>]
    public AirwayType Type { get; init; }

    /// <inheritdoc cref="Terms.Level"/>
    [Character(46), Transform<LevelConverter>]
    public Level Level { get; init; }

    /// <inheritdoc cref="AirwayRestriction"/>
    [Character(47), Transform<AirwayRestrictionConverter>]
    public AirwayRestriction Restriction { get; init; }

    /// <inheritdoc cref="Records.CruiseTable"/>
    [Foreign(48, 49)]
    public CruiseTable? CruiseTable { get; init; }

    /// <summary>
    /// <c>EU Indicator (EU IND)</c> character.
    /// </summary>
    /// <remarks>See section 5.164.</remarks>
    [Character(50), Transform<BoolConverter>]
    public bool HasRestrictions { get; init; }

    /// <summary>
    /// <c>Recommended NAVAID (RECD NAV)</c> and <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See section 5.23 and 5.14.</remarks>
    [Foreign(51, 54), Foreign(55, 56)]
    public OmnidirectionalStation? RecommendedNavaid { get; init; }

    /// <include file='Comments.xml' path="doc/member[@name='RNP']/*"/>
    [Field(57, 59), Decode<RnpConverter>]
    public float RequiredNavigationPerformance { get; init; }

    /// <include file='Comments.xml' path="doc/member[@name='Theta']/*"/>
    [Field(63, 66), Decode<TenthsNumericConverter>]
    public float Theta { get; init; }

    /// <include file='Comments.xml' path="doc/member[@name='Rho']/*"/>
    [Field(67, 70), Decode<TenthsNumericConverter>]
    public float Rho { get; init; }

    /// <include file='Comments.xml' path="doc/member[@name='OutboundMagneticCourse']/*"/>
    [Field(71, 74), Decode<InOutCourseConverter>]
    public float CourseOut { get; init; }

    /// <inheritdoc cref="CourseType"/>
    [Field(73, 74), Decode<InOutCourseTypeConverter>]
    public CourseType CourseOutType { get; init; }

    /// <include file='Comments.xml' path="doc/member[@name='RouteDistanceFrom']/*"/>
    [Field(75, 78), Decode<TenthsNumericConverter>]
    public float DistanceFrom { get; init; }

    /// <include file='Comments.xml' path="doc/member[@name='InboundMagneticCourse']/*"/>
    [Field(79, 82), Decode<InOutCourseConverter>]
    public float CourseIn { get; init; }

    /// <inheritdoc cref="CourseType"/>
    [Field(81, 82), Decode<InOutCourseTypeConverter>]
    public CourseType CourseInType { get; init; }

    /// <include file='Comments.xml' path="doc/member[@name='MinimumAltitude']/*"/>
    [Field(84, 88), Decode<AltitudeConverter>]
    public (int Altitude, AltitudeUnit Unit) Minimum { get; init; }

    /// <include file='Comments.xml' path="doc/member[@name='MinimumAltitude']/*"/>
    [Field(89, 93), Decode<AltitudeConverter>]
    public (int Altitude, AltitudeUnit Unit) Minimum2 { get; init; }

    /// <include file='Comments.xml' path="doc/member[@name='MaximumAltitude']/*"/>
    [Field(94, 98), Decode<AltitudeConverter>]
    public (int Altitude, AltitudeUnit Unit) Maximum { get; init; }

    /// <summary>
    /// <c>Fixed Radius Transition Indicator (FIXED RAD IND)</c> field.
    /// </summary>
    /// <value>Nautical miles and tenths of miles.</value>
    /// <remarks>See section 5.254</remarks>
    [Field(99, 101), Decode<TenthsNumericConverter>]
    public float FixRadius { get; init; }

    /// <include file='Comments.xml' path="doc/member[@name='VSF']/*"/>
    [Field(102, 104), Decode<NumericConverter>]
    public int VerticalScaleFactor { get; init; }

    /// <include file='Comments.xml' path="doc/member[@name='RvsmMinimum']/*"/>
    [Field(105, 107), Decode<NumericConverter>]
    public int MinLevel { get; init; }

    /// <include file='Comments.xml' path="doc/member[@name='RvsmMaximum']/*"/>
    [Field(108, 110), Decode<NumericConverter>]
    public int MaxLevel { get; init; }
}
