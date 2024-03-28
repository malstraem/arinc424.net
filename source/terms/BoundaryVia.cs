namespace Arinc.Spec424.Terms;

/// <summary>
/// <c>Boundary Via (BDRY VIA)</c> character.
/// </summary>
/// <remarks>See section 5.118.</remarks>
public enum BoundaryVia : byte
{
    Unknown,
    Circle,
    GreatCircle,
    RhumbLine,
    CounterClockwiseArc,
    ClockwiseArc
}
