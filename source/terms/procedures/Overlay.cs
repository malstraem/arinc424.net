namespace Arinc424.Procedures.Terms;

/// <summary>
/// <c>GNSS/FMS Indicator (GNSS/FMS IND)</c> character.
/// </summary>
/// <remarks>See section 5.222.</remarks>
public enum Overlay : byte
{
    Unknown,
    /// <summary>
    /// Procedure not authorized for GNSS or FMS overlay.
    /// </summary>
    NotAuthorized,
    /// <summary>
    /// Procedure authorized for GNSS Overlay, primary Navaids operating and monitored.
    /// </summary>
    Monitored,
    /// <summary>
    /// Procedure authorized for GNSS Overlay, primary Navaids installed, not monitored.
    /// </summary>
    NotMonitored,
    /// <summary>
    /// Procedure authorized for GNSS Overlay, Procedure Title includes GPS or GNSS.
    /// </summary>
    Global,
    /// <summary>
    /// Procedure authorized for FMS Overlay.
    /// </summary>
    FlightManagement,
    /// <summary>
    /// RNAV (GPS), RNAV (RNP) or RNAV (GNSS) Procedure SBAS use authorized, SBAS-based vertical navigation authorized.
    /// </summary>
    AreaNavigation,
    /// <summary>
    /// RNAV (GPS), RNAV (RNP), RNAV (GNSS) or RNAV Visual Procedure, SBAS-based vertical navigation not authorized.
    /// </summary>
    AreaNavigationVisual,
    /// <summary>
    /// RNAV (GPS) RNAV (RNP), or RNAV (GNSS) Procedure, SBAS-based vertical navigation use not published.
    /// </summary>
    SatelliteAugmentNotPublished,
    /// <summary>
    /// RNAV (GPS) RNAV (RNP), or RNAV (GNSS) Procedure within the SBAS operational footprint, but SBAS-based vertical navigation not authorized.
    /// </summary>
    SatelliteAugmentFootprint,
    /// <summary>
    /// Stand Alone GPS (GNSS) Procedure.
    /// </summary>
    StandAlone,
    /// <summary>
    /// Procedure Overlay authorization not published.
    /// </summary>
    NotPublished
}
