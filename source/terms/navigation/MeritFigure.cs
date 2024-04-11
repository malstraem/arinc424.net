namespace Arinc424.Navigation.Terms;

/// <summary>
/// <c>Figure of Merit (MERIT)</c> character.
/// </summary>
/// <remarks>See section 5.149.</remarks>
public enum MeritFigure : byte
{
    Unknown,
    /// <summary>
    /// Terminal Use (generally within 25NM).
    /// </summary>
    Terminal,
    /// <summary>
    /// Low Altitude Use (generally within 40NM).
    /// </summary>
    LowAltitude,
    /// <summary>
    /// High Altitude Use (generally within 130NM).
    /// </summary>
    HighAltitude,
    /// <summary>
    /// Extended High Altitude Use (generally beyond 130NM).
    /// </summary>
    ExtendedHighAltitude,
    /// <summary>
    /// Navaid not included in a civil international NOTAM system.
    /// </summary>
    NotIncluded,
    /// <summary>
    /// Navaid Out of Service.
    /// </summary>
    ServiceOut
}
