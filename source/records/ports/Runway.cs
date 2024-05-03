using System.Diagnostics;

using Arinc424.Attributes;
using Arinc424.Converters;
using Arinc424.Navigation;

namespace Arinc424.Ports;

#pragma warning disable CS8618

/// <summary>
/// <c>Runway</c> primary record.
/// </summary>
/// <remarks>See section 4.1.10.1.</remarks>
[Section('P', 'G', subsectionIndex: 13), Continuous]
[DebuggerDisplay($"{{{nameof(Identifier)}}}, {nameof(Airport)} - {{{nameof(Airport)}}}")]
public class Runway : Geo, IIdentity, IIcao
{
    [Foreign(7, 12), Primary]
    public Airport Airport { get; set; }

    /// <summary>
    /// <c>Runway Identifier (RUNWAY ID)</c> field.
    /// </summary>
    /// <remarks>See section 5.46.</remarks>
    [Field(14, 18), Primary]
    public string Identifier { get; set; }

    [Field(11, 12), Primary]
    public string IcaoCode { get; set; }

    /// <summary>
    /// <c>Runway Length (RUNWAY LENGTH)</c> field.
    /// </summary>
    /// <value>Feet.</value>
    /// <remarks>See section 5.57.</remarks>
    [Field(23, 27), Decode<IntConverter>]
    public int Length { get; set; }

    /// <summary>
    /// <c>Runway Magnetic Bearing (RWY BRG)</c> field.
    /// </summary>
    /// <value>Degrees and tenths of a degree.</value>
    /// <remarks>See section 5.58.</remarks>
    [Field(28, 31), Decode<CourseConverter>]
    public Course Bearing { get; set; }

    /// <summary>
    /// <c>Runway Gradient (RWY GRAD)</c> field.
    /// </summary>
    /// <value>Percent.</value>
    /// <remarks>See section 5.212.</remarks>
    [Field(52, 56), Decode<ThousandsConverter>]
    public float Gradient { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='EllipsoidalHeight']/*"/>
    [Field(61, 66), Decode<TenthsConverter>]
    public float EllipsoidalHeight { get; set; }

    /// <summary>
    /// <c>Landing Threshold Elevation (LANDING THRES ELEV)</c> field.
    /// </summary>
    /// <value>Feet.</value>
    /// <remarks>See section 5.68.</remarks>
    [Field(67, 71), Decode<IntConverter>]
    public int ThresholdElevation { get; set; }

    /// <summary>
    /// <c>Threshold Displacement Distance (DSPLCD THR)</c> field.
    /// </summary>
    /// <value>Feet.</value>
    /// <remarks>See section 5.69.</remarks>
    [Field(72, 75), Decode<IntConverter>]
    public int ThresholdDistance { get; set; }

    /// <summary>
    /// <c>Runway Width (WIDTH)</c> field.
    /// </summary>
    /// <value>Feet.</value>
    /// <remarks>See section 5.109.</remarks>
    [Field(78, 80), Decode<IntConverter>]
    public int Width { get; set; }

    /// <inheritdoc cref="Terms.ThresholdType"/>
    [Character(81), Transform<ThresholdTypeConverter>]
    public Terms.ThresholdType ThresholdType { get; set; }

    /// <summary>
    /// <c>Stopway</c> field.
    /// </summary>
    /// <value>Feet.</value>
    /// <remarks>See section 5.79.</remarks>
    [Field(87, 90), Decode<IntConverter>]
    public int Stopway { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='TCH']/*"/>
    [Field(96, 98), Decode<IntConverter>]
    public int ThresholdHeight { get; set; }

    /// <summary>
    /// <c>Runway Description (RUNWAY DESCRIPTION)</c> field.
    /// </summary>
    /// <remarks>See section 5.59.</remarks>
    [Field(102, 123)]
    public string? Description { get; set; }

    /// <summary>
    /// Associated GLS.
    /// </summary>
    [One]
    public GlobalLandingSystem? GlobalLandingSystem { get; set; }

    /// <summary>
    /// Associated MLS.
    /// </summary>
    [One]
    public MicrowaveLandingSystem? MicrowaveLandingSystem { get; set; }

    /// <summary>
    /// Associated ILS.
    /// </summary>
    [One]
    public InstrumentLandingSystem? InstrumentLandingSystem { get; set; }

    /// <summary>
    /// Associated ILS Markers.
    /// </summary>
    [Many]
    public List<InstrumentLandingMarker>? Markers { get; set; }
}
