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
    ElectronicGlideSlope,
    RnavProcedure,
    Default
}
