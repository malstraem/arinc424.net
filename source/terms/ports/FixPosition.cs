namespace Arinc424.Ports.Terms;

/// <summary>
/// <c>Fix Position Indicator</c> character.
/// </summary>
/// <remarks>See section 5.272.</remarks>
[Char, Transform<FixPositionConverter, FixPosition>]
[Description("Fix Position Indicator")]
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
