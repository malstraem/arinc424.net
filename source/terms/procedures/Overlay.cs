namespace Arinc424.Procedures.Terms;

/// <summary>
/// <c>GNSS/FMS Indicator (GNSS/FMS IND)</c> character.
/// </summary>
/// <remarks>See section 5.222.</remarks>
[Char, Transform<OverlayConverter>]
public enum Overlay : byte
{
    Unknown,
    /// <summary>
    /// Procedure not authorized for GNSS or FMS overlay.
    /// </summary>
    [Map('0')] Unauthorized,
    /// <summary>
    /// Procedure authorized for GNSS Overlay, primary Navaids operating and monitored.
    /// </summary>
    [Map('1')] Monitored,
    /// <summary>
    /// Procedure authorized for GNSS Overlay, primary Navaids installed, not monitored.
    /// </summary>
    [Map('2')] Unmonitored,
    /// <summary>
    /// Procedure authorized for GNSS Overlay, Procedure Title includes GPS or GNSS.
    /// </summary>
    [Map('3')] Global,
    /// <summary>
    /// Procedure authorized for FMS Overlay.
    /// </summary>
    [Map('4')] FlightManagement,
    /// <summary>
    /// RNAV (GPS), RNAV (RNP) or RNAV (GNSS) Procedure SBAS use authorized, SBAS-based vertical navigation authorized.
    /// </summary>
    [Map('A')] AreaNavigation,
    /// <summary>
    /// RNAV (GPS), RNAV (RNP), RNAV (GNSS) or RNAV Visual Procedure, SBAS-based vertical navigation not authorized.
    /// </summary>
    [Map('B')] AreaNavigationVisual,
    /// <summary>
    /// RNAV (GPS) RNAV (RNP), or RNAV (GNSS) Procedure, SBAS-based vertical navigation use not published.
    /// </summary>
    [Map('C')] SatelliteAugmentNotPublished,
    /// <summary>
    /// RNAV (GPS) RNAV (RNP), or RNAV (GNSS) Procedure within the SBAS operational footprint, but SBAS-based vertical navigation not authorized.
    /// </summary>
    [Map('D')] SatelliteAugmentFootprint,
    /// <summary>
    /// Stand Alone GPS (GNSS) Procedure.
    /// </summary>
    [Map('P')] Standalone,
    /// <summary>
    /// Procedure Overlay authorization not published.
    /// </summary>
    [Map('U')] Unspecified
}
