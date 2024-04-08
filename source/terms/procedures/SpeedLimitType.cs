namespace Arinc424.Procedures.Terms;

/// <summary>
/// <c>Speed Limit Description (SLD)</c> character.
/// </summary>
/// <remarks>See section 5.261.</remarks>
public enum SpeedLimitType : byte
{
    Unknown,
    /// <summary>
    /// Mandatory Speed, Cross Fix AT speed specified in Speed Limit.
    /// </summary>
    Mandatory,
    /// <summary>
    /// Minimum Speed, Cross Fix AT or ABOVE speed specified in Speed Limit.
    /// </summary>
    Minimum,
    /// <summary>
    /// Maximum Speed, Cross Fix AT or BELOW speed specified in Speed Limit.
    /// </summary>
    Maximum
}
