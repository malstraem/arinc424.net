namespace Arinc424.Ports.Terms;

/// <summary>
/// <c>Longest Runway Surface Code (LRSC)</c> character.
/// </summary>
/// <remarks>See section 5.249.</remarks>
public enum RunwaySurfaceType : byte
{
    Unknown,
    /// <summary>
    /// Hard runway, for example, asphalt or concrete.
    /// </summary>
    Hard,
    /// <summary>
    /// Soft runway, for example, gravel, grass or soil.
    /// </summary>
    Soft,
    /// <summary>
    /// Water runway.
    /// </summary>
    Water
}
