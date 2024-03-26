using Arinc.Spec424.Attributes;
using Arinc.Spec424.Terms.Converters;

namespace Arinc.Spec424.Terms;

/// <summary>
/// <c>TCH Value Indicator (TCHVI)</c> character. See paragraph 5.270.
/// </summary>
/// <remarks><see cref="TransformAttribute">Transformed</see> by <see cref="ThresholdCrossingTypeConverter"/>.</remarks>
public enum ThresholdCrossingType : byte
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
    /// <remarks>See section 5.67<./remarks>
    Default
}
