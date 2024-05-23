namespace Arinc424;

/// <summary>
/// <c>Public/Military Indicator (PUB/MIL)</c> character.
/// </summary>
/// <remarks>See section 5.177.</remarks>
[Char, Flags, Transform<PrivacyConverter>]
public enum Privacy : byte
{
    Unknown = 0,
    /// <summary>
    /// Airport/Heliport is open to the public (civil).
    /// </summary>
    [Map('C')] Civil = 1,
    /// <summary>
    /// Airport/Heliport is military.
    /// </summary>
    [Map('M')] Military = 1 << 1,
    /// <summary>
    /// Airport/Heliport is not open to the public (private).
    /// </summary>
    [Map('P')] Private = 1 << 2,
    [Map('J')] Joint = Civil | Military
}
