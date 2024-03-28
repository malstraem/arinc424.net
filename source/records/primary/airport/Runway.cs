using System.Diagnostics;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Terms;
using Arinc.Spec424.Converters;

namespace Arinc.Spec424.Records;

#pragma warning disable CS8618

/// <summary>
/// <c>Runway</c> primary record.
/// </summary>
/// <remarks>See section 4.1.10.1.</remarks>
[Record('P', 'G', subsectionIndex: 13), Continuous]
[DebuggerDisplay($"{{{nameof(Identifier)}}}")]
public class Runway : Geo, IIdentity, IIcao
{
    [Foreign(7, 12), Primary]
    public Airport Airport { get; init; }

    /// <summary>
    /// <c>Runway Identifier (RUNWAY ID)</c> field.
    /// </summary>
    /// <remarks>See section 5.46.</remarks>
    [Field(14, 18), Primary]
    public string Identifier { get; init; }

    /// <summary>
    /// Only for linking process.
    /// </summary>
    [Field(11, 12), Primary, Obsolete]
    public string IcaoCode { get; init; }

    /// <summary>
    /// <c>Runway Length (RUNWAY LENGTH)</c> field.
    /// </summary>
    /// <remarks>See section 5.57.</remarks>
    [Field(23, 27), Decode<NumericConverter>]
    public int Length { get; init; }

    /// <summary>
    /// <c>Runway Magnetic Bearing (RWY BRG)</c> field.
    /// </summary>
    /// <remarks>See section 5.58.</remarks>
    [Field(28, 31)]
    public string MagneticBearing { get; init; }

    /// <summary>
    /// <c>Runway Gradient (RWY GRAD)</c> field.
    /// </summary>
    /// <remarks>See section 5.212.</remarks>
    [Field(52, 56), Decode<RunwayGradientConverter>]
    public float? Gradient { get; init; }

    /// <summary>
    /// <c>Ellipsoidal Height</c> field.
    /// </summary>
    /// <remarks>See section 5.225.</remarks>
    [Field(61, 66), Decode<TenthsNumericConverter>]
    public float? EllipsoidHeight { get; init; }

    /// <summary>
    /// <c>Landing Threshold Elevation (LANDING THRES ELEV)</c> field.
    /// </summary>
    /// <remarks>See section 5.68.</remarks>
    [Field(67, 71), Decode<NumericConverter>]
    public int ThresholdElevation { get; init; }

    /// <summary>
    /// <c>Threshold Displacement Distance (DSPLCD THR)</c> field.
    /// </summary>
    /// <remarks>See section 5.69.</remarks>
    [Field(72, 75), Decode<NumericConverter>]
    public int? ThresholdDisplacementDistance { get; init; }

    /// <summary>
    /// <c>Runway Width (WIDTH)</c> field.
    /// </summary>
    /// <remarks>See section 5.109.</remarks>
    [Field(78, 80), Decode<NumericConverter>]
    public int Width { get; init; }

    [Character(81), Transform<ThresholdCrossingTypeConverter>]
    public ThresholdCrossingType ThresholdCrossingType { get; init; }

    /// <summary>
    /// <c>Stopway</c> field.
    /// </summary>
    /// <remarks>See section 5.79.</remarks>
    [Field(87, 90), Decode<NumericConverter>]
    public int? Stopway { get; init; }

    /// <summary>
    /// <c>Threshold Crossing Height (TCH)</c> field.
    /// </summary>
    /// <remarks>See section 5.67.</remarks>
    [Field(96, 98), Decode<NumericConverter>]
    public int? ThresholdCrossingHeight { get; init; }

    /// <summary>
    /// <c>Runway Description (RUNWAY DESCRIPTION)</c> field.
    /// </summary>
    /// <remarks>See section 5.59.</remarks>
    [Field(102, 123)]
    public string? Description { get; init; }
}
