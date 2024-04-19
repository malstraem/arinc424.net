using Arinc424.Attributes;
using Arinc424.Converters;

namespace Arinc424.Navigation;

#pragma warning disable CS8618

/// <summary>
/// <c>Airport and Heliport Localizer and Glide Slope</c> primary record.
/// </summary>
/// <remarks>See section 4.1.11.1.</remarks>
[Section('P', 'I', subsectionIndex: 13)]
public class InstrumentLandingSystem : LandingSystem
{
    /// <summary>
    /// <c>Localizer Frequency (FREQ)</c> field.
    /// </summary>
    /// <value>Kilohertz.</value>
    /// <remarks>See section 5.45.</remarks>
    [Field(23, 27), Decode<LocalizerFrequencyConverter>]
    public int Frequency { get; set; }

    [Field(56, 74), Decode<CoordinatesConverter>]
    public Coordinates GlideSlopeCoordinates { get; set; }

    /// <summary>
    /// <c>Localizer Position (LOC FR RW END)</c> field.
    /// </summary>
    /// <value>Feet.</value>
    /// <remarks>See section 5.48.</remarks>
    [Field(75, 78), Decode<IntConverter>]
    public int Position { get; set; }

    [Character(79), Obsolete("TODO combine with position")]
    public char PositionReference { get; set; }

    /// <summary>
    /// <c>Glide Slope Position (GS FR RW THRES)</c> field.
    /// </summary>
    /// <value>Feet.</value>
    /// <remarks>See section 5.50.</remarks>
    [Field(80, 83), Decode<IntConverter>]
    public int GlideSlopePosition { get; set; }

    /// <summary>
    /// <c>Localizer Width (LOC WIDTH)</c> field.
    /// </summary>
    /// <value>Degrees and hundredths of degree.</value>
    /// <remarks>See section 5.51.</remarks>
    [Field(84, 87), Decode<HundredthsConverter>]
    public float Width { get; set; }

    /// <summary>
    /// <c>Glide Slope Angle (GS ANGLE)</c> field.
    /// </summary>
    /// <value>Degrees and hundredths of degree.</value>
    /// <remarks>See section 5.52.</remarks>
    [Field(88, 90), Decode<HundredthsConverter>]
    public float SlopeAngle { get; set; }

    [Field(91, 95), Obsolete("TODO")]
    public string Declination { get; set; }

    [Type(109, 110)]
    [Foreign(7, 12), Foreign(103, 108)]
    public Geo? SupportingFacility { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='TCH']/*"/>
    [Field(111, 113), Decode<IntConverter>]
    public int ThresholdHeight { get; set; }
}
