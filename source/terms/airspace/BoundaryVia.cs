namespace Arinc424.Airspace.Terms;

/// <summary>
/// <c>Boundary Via (BDRY VIA)</c> character.
/// </summary>
/// <remarks>See section 5.118.</remarks>
[Char, Transform<BoundaryViaConverter>]
[Description("Boundary Via (BDRY VIA)")]
public enum BoundaryVia : byte
{
    Unknown,
    [Map('C')] Circle,
    [Map('G')] GreatCircle,
    [Map('H')] RhumbLine,
    [Map('L')] CounterClockwiseArc,
    [Map('R')] ClockwiseArc
}
