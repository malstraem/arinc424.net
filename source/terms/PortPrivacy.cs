namespace Arinc.Spec424.Terms;

/// <summary>
/// <c>Public/Military Indicator (PUB/MIL)</c> character.
/// </summary>
/// <remarks>See paragraph 5.177.</remarks>
[Flags]
public enum PortPrivacy : byte
{
    Unknown,
    Civil,
    Military,
    Private
}
