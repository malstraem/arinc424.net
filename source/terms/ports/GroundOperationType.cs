namespace Arinc424.Ports.Terms;

/// <summary>
/// <c>Operation Type (OPS TYPE)</c> field, specific for <see cref="GroundPathPoint"/>.
/// </summary>
/// <remarks>See section 5.223.</remarks>
[String, Decode<GroundOperationTypeConverter, GroundOperationType>]
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
