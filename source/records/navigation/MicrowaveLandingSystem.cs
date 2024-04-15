using Arinc424.Attributes;
using Arinc424.Converters;

namespace Arinc424.Navigation;

#pragma warning disable CS8618

/// <summary>
/// <c>Airport and Heliport MLS (Azimuth, Elevation and Back Azimuth)</c> primary record.
/// </summary>
/// <remarks>See section 4.1.22.1.</remarks>
[Section('P', 'L', subsectionIndex: 13)]
public class MicrowaveLandingSystem : LandingSystem
{
    /// <summary>
    /// <c>Channel</c> field.
    /// </summary>
    /// <remarks>See section 5.166.</remarks>
    [Field(23, 25), Decode<IntConverter>]
    public int Channel { get; set; }

    [Field(56, 74), Decode<CoordinatesConverter>]
    public Coordinates ElevationCoordinates { get; set; }

    /// <summary>
    /// <c>Azimuth/Back Azimuth Position (AZ/BAZ FR RW END)</c> field.
    /// </summary>
    /// <value>Feet.</value>
    /// <remarks>See section 5.48.</remarks>
    [Field(75, 78), Decode<IntConverter>]
    public int Position { get; set; }

    /// <summary>
    /// <c>Azimuth Position Reference (@, +, -)</c> character.
    /// </summary>
    /// <remarks>See section 5.49.</remarks>
    [Character(79), Obsolete("TODO combine with position")]
    public char PositionReference { get; set; }

    /// <summary>
    /// <c>Elevation Position (EL FR RW THRES)</c> field.
    /// </summary>
    /// <remarks>See section 5.50.</remarks>
    [Field(80, 83), Decode<IntConverter>]
    public int ElevationPosition { get; set; }

    /// <summary>
    /// <c>Azimuth Proportional Angle Right (AZ PRO RIGHT)</c> field.
    /// </summary>
    /// <value>Degrees.</value>
    /// <remarks>See section 5.168.</remarks>
    [Field(84, 86), Decode<IntConverter>]
    public int RightAngle { get; set; }

    /// <summary>
    /// <c>Azimuth Proportional Angle Left (AZ PRO LEFT)</c> field.
    /// </summary>
    /// <value>Degrees.</value>
    /// <remarks>See section 5.168.</remarks>
    [Field(87, 89), Decode<IntConverter>]
    public int LeftAngle { get; set; }

    /// <summary>
    /// <c>Azimuth Coverage Sector Right (AZ COV RIGHT)</c> field.
    /// </summary>
    /// <value>Degrees.</value>
    /// <remarks>See section 5.172.</remarks>
    [Field(90, 92), Decode<IntConverter>]
    public int RightCoverage { get; set; }

    /// <summary>
    /// <c>Azimuth Coverage Sector Left (AZ COV LEFT)</c> field.
    /// </summary>
    /// <value>Degrees.</value>
    /// <remarks>See section 5.172.</remarks>
    [Field(93, 95), Decode<IntConverter>]
    public int LeftCoverage { get; set; }

    /// <summary>
    /// <c>Elevation Angle Span (EL ANGLE SPAN)</c> field.
    /// </summary>
    /// <value>Degrees and tenths of degree.</value>
    /// <remarks>See section 5.169.</remarks>
    [Field(96, 98), Decode<TenthsConverter>]
    public float AngleSpan { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='MagneticVariation']/*"/>
    [Field(99, 103), Decode<MagneticVariationConverter>]
    public string MagneticVariation { get; set; }

    /// <summary>
    /// <c>Nominal Elevation Angle (NOM ELEV ANGLE)</c> field.
    /// </summary>
    /// <value>Degrees and hundredths of degree.</value>
    /// <remarks>See section 5.173.</remarks>
    [Field(109, 112), Decode<HundredthsConverter>]
    public float NominalElevationAngle { get; set; }

    /// <summary>
    /// <c>Glide Slope Angle (GS ANGLE)</c> field.
    /// </summary>
    /// <remarks>See section 5.52.</remarks>
    [Field(113, 115), Decode<HundredthsConverter>]
    public float MinimumGlideAngle { get; set; }

    [Type(122, 123)]
    [Foreign(7, 12), Foreign(116, 121)]
    public Geo? SupportingFacility { get; set; }
}
