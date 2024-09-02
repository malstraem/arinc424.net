namespace Arinc424.Ports.Terms;

/// <summary>
/// <c>TCH Value Indicator (TCHVI)</c> character.
/// </summary>
/// <remarks>See section 5.270.</remarks>
[Char, Transform<ThresholdTypeConverter, ThresholdType>]
[Description("TCH Value Indicator (TCHVI)")]
public enum ThresholdType : byte
{
    Unknown,
    /// <summary>
    /// TCH provided in Runway Record is that of the Electronic Glide Slope.
    /// </summary>
    [Map('I')] ElectronicGlideSlope,
    /// <summary>
    /// TCH provided in Runway Record is that of an RNAV procedure to the runway.
    /// </summary>
    [Map('R')] AreaNavigation,
    /// <summary>
    /// TCH Provided in the Runway Record is that of the VGSI for the runway
    /// </summary>
    [Map('V')] Visual,
    /// <summary>
    /// TCH provided in the Runway Record is the default value of 40 or 50 feet.
    /// </summary>
    /// <remarks>See section 5.67.</remarks>
    [Map('D')] Default
}
