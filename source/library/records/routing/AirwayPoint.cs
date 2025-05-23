using Arinc424.Navigation;
using Arinc424.Processing;
using Arinc424.Tables;
using Arinc424.Waypoints.Terms;

namespace Arinc424.Routing;

/**<summary>
Fields of <c>Enroute Airways</c> primary record.
</summary>
<remarks>Used by <see cref="Airway"/> like subsequence.</remarks>*/
[Pipeline<AirwayPointSorting>]

[DebuggerDisplay($"{nameof(Fix)} - {{{nameof(Fix)}}}")]
public class AirwayPoint : Record424, ISequenced
{
    [Field(26, 29), Integer]
    public int SeqNumber { get; set; }

    [Type(37, 38)]
    [Identifier(30, 34), Icao(35, 36)]
    public Fix Fix { get; set; }

    /// <inheritdoc cref="WaypointDescriptions"/>
    [Field(40, 43)]
    public WaypointDescriptions Descriptions { get; set; }

    /// <inheritdoc cref="Terms.BoundaryCode"/>
    [Character(44)]
    public Terms.BoundaryCode BoundaryCode { get; set; }

    /// <inheritdoc cref="Terms.AirwayType"/>
    [Character(45)]
    public Terms.AirwayType Type { get; set; }

    /// <inheritdoc cref="Arinc424.LevelType"/>
    [Character(46)]
    public LevelType LevelType { get; set; }

    /// <inheritdoc cref="Terms.AirwayRestriction"/>
    [Character(47)]
    public Terms.AirwayRestriction Restriction { get; set; }

    /// <inheritdoc cref="Tables.CruiseTable"/>
    [Identifier(48, 49)]
    public CruiseTable? CruiseTable { get; set; }

    /// <summary><c>EU Indicator (EU IND)</c> character.</summary>
    /// <remarks>See section 5.164.</remarks>
    [Character(50)]
    public Bool HasRestrictions { get; set; }

    [Identifier(51, 54), Icao(55, 56)]
    public Omnidirectional? Recommended { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='RNP']/*"/>
    [Field(57, 59), Performance]
    public float Performance { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Theta']/*"/>
    [Field(63, 66), Float(10)]
    public float Theta { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Rho']/*"/>
    [Field(67, 70), Float(10)]
    public float Rho { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='OutboundMagneticCourse']/*"/>
    [Field(71, 74)]
    public Course Out { get; set; }

    /**<summary>
    <c>Route Distance From (RTE DIST FROM)</c> field.
    </summary>
    <value>Nautical miles.</value>
    <remarks>See section 5.27.</remarks>*/
    [Field(75, 78), Float(10)]
    public float DistanceFrom { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='InboundMagneticCourse']/*"/>
    [Field(79, 82)]
    public Course In { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Altitude']/*"/>
    [Field(84, 88)]
    public Altitude Minimum { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Altitude']/*"/>
    [Field(89, 93)]
    public Altitude Minimum2 { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='MaximumAltitude']/*"/>
    [Field(94, 98)]
    public Altitude Maximum { get; set; }

    /**<summary>
    <c>Fixed Radius Transition Indicator (FIXED RAD IND)</c> field.
    </summary>
    <value>Nautical miles.</value>
    <remarks>See section 5.254</remarks>*/
    [Field(99, 101), Float(10)]
    public float FixRadius { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='VSF']/*"/>
    [Field(102, 104), Integer]
    public int ScaleFactor { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='RvsmMinimum']/*"/>
    [Field(105, 107), Integer]
    public int MinLevel { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='RvsmMaximum']/*"/>
    [Field(108, 110), Integer]
    public int MaxLevel { get; set; }

    [Continue]
    public AirwayContinuation[]? Notes { get; set; }
}
