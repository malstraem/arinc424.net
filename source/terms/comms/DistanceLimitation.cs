namespace Arinc424.Comms.Terms;

/// <summary>
/// <c>Distance Description (DIST DESC)</c> character.
/// </summary>
/// <remarks>See section 5.187.</remarks>
[Char, Transform<DistanceLimitationConverter>]
public enum DistanceLimitation : byte
{
    Unknown,
    /// <summary>
    /// No restrictions/limitations apply.
    /// </summary>
    [Map] None,
    /// <summary>
    /// Communications frequency or navaid limitation is out to a specified distance.
    /// </summary>
    [Map('-')] Out,
    /// <summary>
    /// Communications frequency is used or the navaid limitation applies beyond a specified distance.
    /// </summary>
    [Map('+')] Beyond
}
