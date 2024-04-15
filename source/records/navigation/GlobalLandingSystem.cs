using Arinc424.Attributes;
using Arinc424.Converters;

namespace Arinc424.Navigation;

/// <summary>
/// <c>GLS</c> primary record.
/// </summary>
/// <remarks>See section 4.1.29.1.</remarks>
[Section('P', 'T', subsectionIndex: 13)]
public class GlobalLandingSystem : LandingSystem
{
    /// <summary>
    /// <c>GLS Channel</c> field.
    /// </summary>
    /// <remarks>See section 5.244.</remarks>
    [Field(23, 27), Decode<IntConverter>]
    public int Channel { get; set; }

    /// <summary>
    /// <c>Service Volume Radius</c> field.
    /// </summary>
    /// <remarks>See section 5.245.</remarks>
    [Field(84, 85), Decode<IntConverter>]
    public int Radius { get; set; }

    /// <summary>
    /// <c>TDMA Slots </c> field.
    /// </summary>
    /// <remarks>See section 5.246.</remarks>
    [Field(86, 87), Decode<ByteConverter>]
    public int Slots { get; set; }

    /// <summary>
    /// <c>Glide Slope Angle (GS ANGLE)</c> field.
    /// </summary>
    /// <value>Degrees and hundredths of degree.</value>
    /// <remarks>See section 5.52.</remarks>
    [Field(88, 90), Decode<HundredthsConverter>]
    public float SlopeAngle { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='MagneticVariation']/*"/>
    [Field(91, 95), Decode<MagneticVariationConverter>]
    public float MagneticVariation { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Datum']/*"/>
    [Field(103, 105)]
    public string? Datum { get; set; }

    /// <summary>
    /// <c>Station Type</c> field.
    /// </summary>
    /// <remarks>See section 5.247.</remarks>
    [Field(106, 108)]
    public string? StationType { get; set; }

    /// <summary>
    /// <c>Station Elevation WGS84</c> field.
    /// </summary>
    [Field(111, 115), Decode<IntConverter>]
    public int ElevationWgs84 { get; set; }
}
