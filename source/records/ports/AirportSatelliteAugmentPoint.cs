namespace Arinc424.Ports;

using Terms;

/// <summary>
/// <c>Airport SBAS Path Point</c> primary record.
/// </summary>
/// <remarks>See section 4.1.28.1.</remarks>
[Section('P', 'P', subsectionIndex: 13), Continuous(27)]
public class AirportSatellitePoint : Geo
{
    [Foreign(7, 12)]
    public Airport Airport { get; set; }

    [Obsolete("todo: linking when procedures will be post processed")]
    [Field(14, 19)]
    public string Approach { get; set; }

    [Foreign(7, 12), Foreign(20, 24), Foreign(11, 12)]
    public Runway Runway { get; set; }

    /// <inheritdoc cref="SatelliteOperationType"/>
    [Field(25, 26)]
    public SatelliteOperationType Operation { get; set; }

    /// <summary>
    /// <c>Route Indicator (RTE IND)</c> character.
    /// </summary>
    /// <remarks>See section 5.224.</remarks>
    [Character(28)]
    public char RouteIndicator { get; set; }

    /// <inheritdoc cref="SatelliteService"/>
    [Field(29, 30)]
    public SatelliteService Service { get; set; }

    /// <summary>
    /// <c>Reference Path Data Selector (REF PDS)</c> field.
    /// </summary>
    /// <remarks>See section 5.256.</remarks>
    [Field(31, 32), Integer]
    public int PathSelector { get; set; }

    /// <summary>
    /// <c>Reference Path Identifier (REF ID)</c> field.
    /// </summary>
    /// <remarks>See section 5.257.</remarks>
    [Field(33, 36)]
    public string PathIdentifier { get; set; }

    /// <inheritdoc cref="Terms.ApproachPerformance"/>
    [Character(37)]
    public ApproachPerformance ApproachPerformance { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='EllipsoidalHeight']/*"/>
    [Field(61, 66), Float(10)]
    public float EllipsoidalHeight { get; set; }

    /// <summary>
    /// <c>Glide Path Angle (GPA)</c> field.
    /// </summary>
    /// <remarks>See section 5.226.</remarks>
    [Field(67, 70), Float(100)]
    public float GlideAngle { get; set; }

    /// <summary>
    /// Flight Path Alignment coordinates.
    /// </summary>
    [Field(71, 93)]
    public Coordinates AlignmentCoordinates { get; set; }

    /// <summary>
    /// <c>Course Width At Threshold (CRS WDTH)</c> field.
    /// </summary>
    /// <vallue>Meters.</vallue>
    /// <remarks>See section 5.228.</remarks>
    [Field(94, 98), Float(100)]
    public float CourseWidth { get; set; }
}
