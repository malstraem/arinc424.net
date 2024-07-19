namespace Arinc424.Ports.Terms;

/// <summary>
/// <c>Operation Type (OPS TYPE)</c> field, specific for <see cref="GroundPoint"/>.
/// </summary>
/// <remarks>See section 5.223.</remarks>
[String, Decode<GroundOperationTypeConverter, GroundOperationType>]
[Description("Operation Type (OPS TYPE) - GBAS")]
public enum GroundOperationType : byte
{
    Unknown,
    /// <summary>
    /// Straight-in approach path.
    /// </summary>
    [Map("00")] Straight,
    /// <summary>
    /// Terminal Area path definition (not for FAS Datablock).
    /// </summary>
    [Map("01")] Terminal,
    /// <summary>
    /// Missed Approach (not for FAS Datablock).
    /// </summary>
    [Map("02")] Missed
}
