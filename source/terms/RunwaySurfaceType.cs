using Arinc.Spec424.Attributes;
using Arinc.Spec424.Terms.Converters;

namespace Arinc.Spec424.Terms;

/// <summary>
/// <c>Longest Runway Surface Code (LRSC)</c> character. See paragraph 5.249.
/// </summary>
/// <remarks><see cref="TransformAttribute">Transformed</see> by <see cref="RunwaySurfaceTypeConverter"/>.</remarks>
public enum RunwaySurfaceType : byte
{
    Unknown,
    Hard,
    Soft,
    Water
}
