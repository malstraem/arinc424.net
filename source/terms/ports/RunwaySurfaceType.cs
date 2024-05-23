namespace Arinc424.Ports.Terms;

/// <summary>
/// <c>Longest Runway Surface Code (LRSC)</c> character.
/// </summary>
/// <remarks>See section 5.249.</remarks>
[Char, Transform<RunwaySurfaceTypeConverter>]
public enum RunwaySurfaceType : byte
{
    Unknown,
    /// <summary>
    /// Hard runway, for example, asphalt or concrete.
    /// </summary>
    [Map('H')] Hard,
    /// <summary>
    /// Soft runway, for example, gravel, grass or soil.
    /// </summary>
    [Map('S')] Soft,
    /// <summary>
    /// Water runway.
    /// </summary>
    [Map('W')] Water
}
