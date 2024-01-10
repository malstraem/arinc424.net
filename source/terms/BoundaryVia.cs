using Arinc.Spec424.Terms.Converters;

namespace Arinc.Spec424.Terms;

/// <summary>
/// <c>Boundary Via (BDRY VIA)</c> character.
/// Transforms by <see cref="BoundaryViaConverter"/>.
/// </summary>
/// <remarks>See paragraph 5.118.</remarks>
public enum BoundaryVia : int
{
    Unknown,
    Circle,
    GreatCircle,
    RhumbLine,
    CounterClockwiseArc,
    ClockwiseArc
}
