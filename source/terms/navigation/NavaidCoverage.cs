namespace Arinc424.Navigation.Terms;

/// <summary>
/// Third character of <c>NAVAID Class (CLASS)</c> field.
/// </summary>
/// <remarks>See section 5.35.</remarks>
public enum NavaidCoverage : byte
{
    Unknown,
    /// <summary>
    /// Generally usable within 25NM of the facility and below 12000 feet.
    /// </summary>
    Terminal,
    /// <summary>
    /// Generally usable within 40NM of the facility and up to 18000 feet.
    /// </summary>
    LowAltitude,
    /// <summary>
    /// Generally usable Within 130NM of the facility and up to 60000 feet.
    /// </summary>
    HighAltitude,
    /// <summary>
    /// Coverage not defined by government source.
    /// </summary>
    Undefined,
    /// <summary>
    /// Full TACAN facility frequency-paired and operating with the same identifier as an ILS Localizer.
    /// </summary>
    InstrumentLandingTactical,
    /// <summary>
    /// Generally usable within 75NM of the facility at all altitudes.
    /// </summary>
    HighPowered,
    /// <summary>
    /// Generally usable within 50NM of the facility at all altitudes.
    /// </summary>
    Default,
    /// <summary>
    /// Generally usable within 25NM of the facility at all altitude.
    /// </summary>
    LowPowered,
    /// <summary>
    /// Generally usable within 15NM of the facility at all altitudes.
    /// </summary>
    Locator
}
