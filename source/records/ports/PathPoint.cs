namespace Arinc424.Ports;

using Terms;

[Continuous(27)]
[DebuggerDisplay($"{{{nameof(Identifier)}}}")]
public abstract class PathPoint : Geo, IIcao, IIdentity
{
    [Field(11, 12)]
    public string IcaoCode { get; set; }

    /// <inheritdoc cref="SatelliteOperationType"/>
    [Field(25, 26)]
    public SatelliteOperationType Operation { get; set; }

    /// <summary>
    /// <c>Route Indicator (RTE IND)</c> character.
    /// </summary>
    /// <remarks>See section 5.224.</remarks>
    [Character(28)]
    public char RouteIndicator { get; set; }

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
    public string Identifier { get; set; }

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

    /// <summary>
    /// <c>Length Offset (OFFSET)</c> field.
    /// </summary>
    /// <remarks>See section 5.259.</remarks>
    [Field(99, 102), Integer]
    public int LengthOffset { get; set; }

    /// <inheritdoc cref="Terms.ThresholdHeight"/>
    [Field(103, 109)]
    public ThresholdHeight ThresholdHeight { get; set; }

    /// <summary>
    /// <c>Final Approach Segment Data CRC Remainder (FAS CRC)</c> field.
    /// </summary>
    /// <remarks>See section 5.229.</remarks>
    [Obsolete("need to convert?")]
    [Field(116, 123)]
    public string Remainder { get; set; }
}
