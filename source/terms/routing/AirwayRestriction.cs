namespace Arinc424.Routing.Terms;

/// <summary>
/// <c>Directional Restriction</c> character.
/// </summary>
/// <remarks>See section 5.115.</remarks>
public enum AirwayRestriction : byte
{
    Unknown,
    /// <summary>
    /// No restrictions on direction.
    /// </summary>
    None,
    /// <summary>
    /// One way in direction route is coded (forward).
    /// </summary>
    Forward,
    /// <summary>
    /// One way in opposite direction route is coded (backward).
    /// </summary>
    Backward
}