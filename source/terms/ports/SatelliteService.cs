namespace Arinc424.Ports.Terms;

/// <summary>
/// <c>SBAS Service Provider Identifier (SBAS ID)</c> field.
/// </summary>
/// <remarks>See section 5.255.</remarks>
[String, Decode<SatelliteServiceConverter, SatelliteService>]
public enum SatelliteService : byte
{
    Unknown,
    /// <summary>
    /// Not intended for SBAS.
    /// </summary>
    [Map("14")] NotIntended,
    /// <summary>
    /// Any Service provider may be used.
    /// </summary>
    [Map("15")] Any,
    /// <summary>
    /// WAAS.
    /// </summary>
    [Map("00")] Waas,
    /// <summary>
    /// EGNOS.
    /// </summary>
    [Map("01")] Egnos,
    /// <summary>
    /// MSAS.
    /// </summary>
    [Map("02")] Msas,
}
