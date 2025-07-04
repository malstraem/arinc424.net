using Arinc424.Navigation;

namespace Arinc424.Ground;

/**<summary>
<c>Runway</c> primary record.
</summary>
<remarks>See section 4.1.10.1.</remarks>*/
[Section('P', 'G', subIndex: 13)]

[Port(7, 10), Icao(11, 12), Identifier(14, 18), Continuous]

[DebuggerDisplay($"{{{nameof(Identifier)},nq}}, {nameof(Port)} - {{{nameof(Port)}}}")]
public class RunwayThreshold : Fix
{
    [Identifier(7, 10)]
    public Port Port { get; set; }

    /**<summary>
    <c>Runway Length (RUNWAY LENGTH)</c> field.
    </summary>
    <value>Feet.</value>
    <remarks>See section 5.57.</remarks>*/
    [Field(23, 27), Integer]
    public int Length { get; set; }

    /**<summary>
    <c>Runway Bearing (RWY BRG)</c> field.
    </summary>
    <value>Degrees.</value>
    <remarks>See section 5.58.</remarks>*/
    [Field(28, 31)]
    public Course Bearing { get; set; }

    /**<summary>
    <c>Runway Gradient (RWY GRAD)</c> field.
    </summary>
    <value>Degrees.</value>
    <remarks>See section 5.212.</remarks>*/
    [Field(52, 56), Float(1000)]
    [Obsolete("todo")]
    public float Gradient { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='EllipsoidalHeight']/*"/>
    [Field(61, 66), Float(10)]
    public float EllipsoidalHeight { get; set; }

    /**<summary>
    <c>Landing Threshold Elevation (LANDING THRES ELEV)</c> field.
    </summary>
    <value>Feet.</value>
    <remarks>See section 5.68.</remarks>*/
    [Field(67, 71), Integer]
    public int Elevation { get; set; }

    /**<summary>
    <c>Threshold Displacement Distance (DSPLCD THR)</c> field.
    </summary>
    <value>Feet.</value>
    <remarks>See section 5.69.</remarks>*/
    [Field(72, 75), Integer]
    public int Distance { get; set; }

    /**<summary>
    <c>Runway Width (WIDTH)</c> field.
    </summary>
    <value>Feet.</value>
    <remarks>See section 5.109.</remarks>*/
    [Field(77, 80), Integer]
    public int Width { get; set; }

    /// <inheritdoc cref="Terms.ThresholdType"/>
    [Character(81)]
    public Terms.ThresholdType Type { get; set; }

    /**<summary>
    <c>Stopway</c> field.
    </summary>
    <value>Feet.</value>
    <remarks>See section 5.79.</remarks>*/
    [Field(87, 90), Integer]
    public int Stopway { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='TCH']/*"/>
    [Field(96, 98), Integer]
    public int Height { get; set; }

    /**<summary>
    <c>Runway Description (RUNWAY DESCRIPTION)</c> field.
    </summary>
    <remarks>See section 5.59.</remarks>*/
    [Field(102, 123)]
    public string? Description { get; set; }

    /// <summary>Associated GLSs.</summary>
    [Many]
    public GlobalLanding[]? GlobalLandings { get; set; }

    /// <summary>Associated MLSs.</summary>
    [Many]
    public MicrowaveLanding[]? MicrowaveLandings { get; set; }

    /// <summary>Associated ILSs.</summary>
    [Many]
    public InstrumentLanding[]? InstrumentLandings { get; set; }

    /// <summary>Associated ILS Markers.</summary>
    [Many]
    public InstrumentMarker[]? Markers { get; set; }
}
