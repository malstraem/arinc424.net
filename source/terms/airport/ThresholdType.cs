namespace Arinc.Spec424.Terms;

/// <summary>
/// <c>TCH Value Indicator (TCHVI)</c> character.
/// </summary>
/// <remarks>See section 5.270.</remarks>
public enum ThresholdType : byte
{
    Unknown,
    /// <summary>
    /// TCH provided in Runway Record is that of the Electronic Glide Slope.
    /// </summary>
    ElectronicGlideSlope,
    /// <summary>
    /// TCH provided in Runway Record is that of an RNAV procedure to the runway.
    /// </summary>
    RnavProcedure,
    /// <summary>
    /// TCH provided in the Runway Record is the default value of 40 or 50 feet.
    /// </summary>
    /// <remarks>See section 5.67.</remarks>
    Default
}
