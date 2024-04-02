namespace Arinc424.Ports.Terms;

/// <summary>
/// <c>Public/Military Indicator (PUB/MIL)</c> character.
/// </summary>
/// <remarks>See section 5.177.</remarks>
[Flags]
public enum PortPrivacy : byte
{
    Unknown = 0,
    /// <summary>
    /// Airport/Heliport is open to the public (civil).
    /// </summary>
    Civil = 1,
    /// <summary>
    /// Airport/Heliport is military.
    /// </summary>
    Military = 1 << 1,
    /// <summary>
    /// Airport/Heliport is not open to the public (private).
    /// </summary>
    Private = 1 << 2
}
