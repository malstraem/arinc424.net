namespace Arinc424.Navigation.Terms;

/// <summary>
/// <c>Navaid Usable Range</c> character.
/// </summary>
/// <remarks>See section 5.149.</remarks>
[Char, Transform<UsableRangeConverter, UsableRange>]
[Description("Navaid Usable Range")]
public enum UsableRange : byte
{
    Unknown,
    /// <summary>
    /// Terminal Use (generally within 25NM).
    /// </summary>
    [Map('0')] Terminal,
    /// <summary>
    /// Low Altitude Use (generally within 40NM).
    /// </summary>
    [Map('1')] LowAltitude,
    /// <summary>
    /// High Altitude Use (generally within 130NM).
    /// </summary>
    [Map('2')] HighAltitude,
    /// <summary>
    /// Extended High Altitude Use (generally beyond 130NM).
    /// </summary>
    [Map('3')] ExtendedHighAltitude,
    /// <summary>
    /// Navaid not included in a civil international NOTAM system.
    /// </summary>
    [Map('7')] NotIncluded,
    /// <summary>
    /// Navaid Out of Service.
    /// </summary>
    [Map('9')] ServiceOut
}
