namespace Arinc424.Navigation.Terms;

/// <summary>
/// <c>DME Operational Service Volume (D-OSV)</c> character.
/// </summary>
/// <remarks>See section 5.277.</remarks>
[Char]
public enum ServiceVolume : byte
{
    Unknown,
    /// <summary>
    /// 40NM or less.
    /// </summary>
    [Map('A')] Alpha,
    /// <summary>
    /// 70NM or less.
    /// </summary>
    [Map('B')] Bravo,
    /// <summary>
    /// 130NM or less.
    /// </summary>
    [Map('C')] Charlie,
    /// <summary>
    /// Greater than 130NM.
    /// </summary>
    [Map('D')] Delta,
    /// <summary>
    /// Unspecified.
    /// </summary>
    [Map('U')] Unspecified
}
