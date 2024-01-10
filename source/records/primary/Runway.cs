using System.Diagnostics;

using Arinc.Spec424.Attributes;

namespace Arinc.Spec424.Records;

#pragma warning disable CS8618

/// <summary>
/// <c>Runway</c> primary record.
/// </summary>
/// <remarks>See paragraph 4.1.10.1.</remarks>
[Record('P', 'G', subsectionIndex: 13), Continuation]
[DebuggerDisplay("Identifier - {Identifier}")]
public class Runway : Geo, IIdentifiable
{
    /// <summary>
    /// <c>Airport Identifier (ARPT IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.6.</remarks>
    [Field(7, 10), Link<Runway, Airport>]
    public string AirportIdentifier { get; init; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.14.</remarks>
    [Field(11, 12)]
    public string IcaoCode { get; init; }

    /// <summary>
    /// <c>Runway Identifier (RUNWAY ID)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.46.</remarks>
    [Field(14, 18)]
    public string Identifier { get; init; }

    /// <summary>
    /// <c>Runway Length (RUNWAY LENGTH)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.57.</remarks>
    [Field(23, 27)]
    public string Length { get; init; }

    /// <summary>
    /// <c>Runway Magnetic Bearing (RWY BRG)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.58.</remarks>
    [Field(28, 31)]
    public string MagneticBearing { get; init; }

    /// <summary>
    /// <c>Runway Gradient (RWY GRAD)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.212.</remarks>
    [Field(52, 56)]
    public string Gradient { get; init; }

    /// <summary>
    /// <c>Ellipsoidal Height</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.225.</remarks>
    [Field(61, 66)]
    public string EllipsoidHeight { get; init; }

    /// <summary>
    /// <c>Landing Threshold Elevation (LANDING THRES ELEV)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.68.</remarks>
    [Field(67, 71)]
    public string ThresholdElevation { get; init; }

    /// <summary>
    /// <c>Threshold Displacement Distance (DSPLCD THR)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.69.</remarks>
    [Field(72, 75)]
    public string DisplacedThresholdDistance { get; init; }

    /// <summary>
    /// <c>Runway Width (WIDTH)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.109.</remarks>
    [Field(78, 80)]
    public string Width { get; init; }

    /// <summary>
    /// <c>TCH Value Indicator (TCHVI)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.270.</remarks>
    [Character(81)]
    public char TcgValueIndicator { get; init; }

    /// <summary>
    /// <c>Stopway</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.79.</remarks>
    [Field(87, 90)]
    public string Stopway { get; init; }

    /// <summary>
    /// <c>Threshold Crossing Height (TCH)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.67.</remarks>
    [Field(96, 98)]
    public string ThresholdCrossingHeight { get; init; }

    /// <summary>
    /// <c>Runway Description (RUNWAY DESCRIPTION)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.59.</remarks>
    [Field(102, 123)]
    public string? Description { get; init; }
}
