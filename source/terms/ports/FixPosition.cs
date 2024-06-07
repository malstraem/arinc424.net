namespace Arinc424.Ports.Terms;

/// <summary>
/// <c>TAA Sector Indicator</c> character.
/// </summary>
/// <remarks>See section 5.272.</remarks>
[Char, Transform<FixPositionConverter, FixPosition>]
public enum FixPosition : byte
{
    Unknown,
    /// <summary>
    /// Straight-In or Center Fix.
    /// </summary>
    [Map('C')] Center,
    /// <summary>
    /// Left Base Area.
    /// </summary>
    [Map('L')] Left,
    /// <summary>
    /// Right Base Area.
    /// </summary>
    [Map('T')] Right
}
