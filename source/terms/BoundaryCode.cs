using Arinc.Spec424.Attributes;
using Arinc.Spec424.Terms.Converters;

namespace Arinc.Spec424.Terms;

/// <summary>
/// <c>Boundary Code (BDY CODE)</c> character. See paragraph 5.18.
/// </summary>
/// <remarks><see cref="TransformAttribute">Transformed</see> by <see cref="BoundaryViaConverter"/>.</remarks>
public enum BoundaryCode : byte
{
    Unknown,
    USA,
    CanadaAlaska,
    Pacific,
    LatinAmerica,
    SouthAmerica,
    SouthPacific,
    Europe,
    EasternEurope,
    MiddleEastSouthAsia,
    Africa
}
