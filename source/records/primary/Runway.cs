using Arinc.Spec424.Attributes;
using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Records;

/// <summary>
/// <c>Runway</c> primary record.
/// </summary>
/// <remarks>See paragraph 4.1.10.1.</remarks>
[Record('P', 'G', subsectionIndex: 13), Continuation]
public class Runway : Record424, IIdentifiable
{
    /// <summary>
    /// <c>Airport Identifier (ARPT IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.6.</remarks>
    [Field(6, 10), Link<Runway, Airport>]
    public required string AirportIdentifier { get; init; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.14.</remarks>
    [Field(10, 12)]
    public required string IcaoCode { get; init; }

    /// <summary>
    /// <c>Runway Identifier (RUNWAY ID)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.46.</remarks>
    [Field(13, 18)]
    public required string Identifier { get; init; }

    /// <summary>
    /// <c>Runway Length (RUNWAY LENGTH)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.57.</remarks>
    [Field(22, 27)]
    public required string Length { get; init; }

    /// <summary>
    /// <c>Runway Magnetic Bearing (RWY BRG)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.58.</remarks>
    [Field(27, 31)]
    public required string MagneticBearing { get; init; }

    /// <summary>
    /// <c>Latitude (LATITUDE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.36.</remarks>
    [Field(32, 41)]
    public required string Latitude { get; init; }

    /// <summary>
    /// <c>Longitude (LONGITUDE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.37.</remarks>
    [Field(41, 51)]
    public required string Longitude { get; init; }

    /// <summary>
    /// <c>Runway Gradient (RWY GRAD)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.212.</remarks>
    [Field(52, 56)]
    public required string Gradient { get; init; }

    /// <summary>
    /// <c>Ellipsoidal Height</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.225.</remarks>
    [Field(60, 66)]
    public required string EllipsoidHeight { get; init; }

    /// <summary>
    /// <c>Landing Threshold Elevation (LANDING THRES ELEV)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.68.</remarks>
    [Field(66, 71)]
    public required string ThresholdElevation { get; init; }

    /// <summary>
    /// <c>Threshold Displacement Distance (DSPLCD THR)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.69.</remarks>
    [Field(71, 75)]
    public required string DisplacedThresholdDistance { get; init; }

    /// <summary>
    /// <c>Runway Width (WIDTH)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.109.</remarks>
    [Field(77, 80)]
    public required string Width { get; init; }

    /// <summary>
    /// <c>TCH Value Indicator (TCHVI)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.270.</remarks>
    [Character(81)]
    public required char TcgValueIndicator { get; init; }

    /// <summary>
    /// <c>Stopway</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.79.</remarks>
    [Field(86, 90)]
    public required string Stopway { get; init; }

    /// <summary>
    /// <c>Threshold Crossing Height (TCH)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.67.</remarks>
    [Field(95, 98)]
    public required string ThresholdCrossingHeight { get; init; }

    /// <summary>
    /// <c>Runway Description (RUNWAY DESCRIPTION)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.59.</remarks>
    [Field(101, 123)]
    public required string? Description { get; init; }
}
