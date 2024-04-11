namespace Arinc424.Navigation.Terms;

/// <summary>
/// <c>DME Operational Service Volume (D-OSV)</c> character.
/// </summary>
/// <remarks>See section 5.277.</remarks>
public enum ServiceVolume : byte
{
    Unknown,
    /// <summary>
    /// 40NM or less.
    /// </summary>
    Alpha,
    /// <summary>
    /// 70NM or less.
    /// </summary>
    Bravo,
    /// <summary>
    /// 130NM or less.
    /// </summary>
    Charlie,
    /// <summary>
    /// Greater than 130NM.
    /// </summary>
    Delta,
    /// <summary>
    /// Unspecified.
    /// </summary>
    Unspecified
}
