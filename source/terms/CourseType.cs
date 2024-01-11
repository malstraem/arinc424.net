using Arinc.Spec424.Attributes;
using Arinc.Spec424.Terms.Converters;

namespace Arinc.Spec424.Terms;

/// <summary>
/// <c>Magnetic/True Indicator (M/T IND)</c> character. See paragraph 5.165.
/// </summary>
/// <remarks><see cref="TransformAttribute">Transformed</see> by <see cref="CourseTypeConverter"/>.</remarks>
public enum CourseType : byte
{
    Unknown,
    Magnetic,
    True,
    Mixed
}
