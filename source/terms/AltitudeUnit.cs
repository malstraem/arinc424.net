namespace Arinc424;

/// <summary>
/// Unit of measurement of different altitudes according to specification.
/// </summary>
public enum AltitudeUnit : byte
{
    Unknown,
    /// <summary>
    /// Altitude has not been specified or established by the appropriate authority.
    /// </summary>
    NotSpecified,
    /// <summary>
    /// Altitude is unlimited.
    /// </summary>
    Unlimited,
    /// <summary>
    /// Altitude is in feet.
    /// </summary>
    Feet,
    /// <summary>
    /// Altitude is flight level.
    /// </summary>
    Level,
    Ground,
    Sea,
    Notam
}
