namespace Arinc.Spec424.Terms;

/// <summary>
/// <c>Public/Military Indicator (PUB/MIL)</c> character.
/// </summary>
/// <remarks>See section 5.177.</remarks>
[Flags]
public enum PortPrivacy : byte
{
    Unknown,
    /// <summary>
    /// Airport/Heliport is open to the public (civil).
    /// </summary>
    Civil,
    /// <summary>
    /// Airport/Heliport is military.
    /// </summary>
    Military,
    /// <summary>
    /// Airport/Heliport is not open to the public (private).
    /// </summary>
    Private
}
