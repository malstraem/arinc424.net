namespace Arinc424.Airspace.Terms;

/// <summary>
/// Circular arc that may be used by <see cref="BoundaryPoint"/>.
/// </summary>
[Decode<ArcConverter>]
[DebuggerDisplay($"{{{nameof(Coordinates)}}}")]
public class Arc(Coordinates coordinates, float? distance, float? bearing)
{
    public Coordinates Coordinates { get; } = coordinates;

    /// <summary>
    /// <c>Arc Distance (ARC DIST) </c> field.
    /// </summary>
    /// <value>Nautical miles and tents of mile.</value>
    /// <remarks>See section 5.119.</remarks>
    public float? Distance { get; } = distance;

    /// <summary>
    /// <c>Arc Bearing (ARC BRG)</c> field.
    /// </summary>
    /// <value>Degrees and tenths of degree.</value>
    /// <remarks>See section 5.120.</remarks>
    public float? Bearing { get; } = bearing;
}
