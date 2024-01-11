using Arinc.Spec424.Attributes;
using Arinc.Spec424.Terms.Converters;

namespace Arinc.Spec424.Terms;

/// <summary>
/// <c>Boundary Via (BDRY VIA)</c> character. See paragraph 5.118.
/// </summary>
/// <remarks><see cref="TransformAttribute">Transformed</see> by <see cref="BoundaryViaConverter"/>.</remarks>
public enum BoundaryVia : int
{
    Unknown,
    Circle,
    GreatCircle,
    RhumbLine,
    CounterClockwiseArc,
    ClockwiseArc
}
