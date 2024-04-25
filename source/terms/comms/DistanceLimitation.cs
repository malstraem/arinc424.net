namespace Arinc424.Comms.Terms;

/// <summary>
/// <c>Distance Description (DIST DESC)</c> character.
/// </summary>
public enum DistanceLimitation : byte
{
    Unknown,
    /// <summary>
    /// No restrictions/limitations apply.
    /// </summary>
    None,
    /// <summary>
    /// Communications frequency or navaid limitation is out to a specified distance.
    /// </summary>
    Out,
    /// <summary>
    /// Communications frequency is used or the navaid limitation applies beyond a specified distance.
    /// </summary>
    Beyond
}
