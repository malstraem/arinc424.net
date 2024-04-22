namespace Arinc424.Airspace;

/// <summary>
/// Circular arc that may be used by <see cref="BoundaryPoint"/>.
/// </summary>
public class Arc : Geo
{
    /// <summary>
    /// <c>Arc Distance (ARC DIST) </c> field.
    /// </summary>
    /// <value>Nautical miles and tents of mile.</value>
    /// <remarks>See section 5.119.</remarks>
    public float Distance { get; set; }

    /// <summary>
    /// <c>Arc Bearing (ARC BRG)</c> field.
    /// </summary>
    /// <value>Degrees and tenths of degree.</value>
    /// <remarks>See section 5.120.</remarks>
    public float Bearing { get; set; }
}
