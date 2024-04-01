namespace Arinc.Spec424.Terms;

/// <summary>
/// <c>Controlled Airspace Type (ARSP TYPE)</c> character.
/// </summary>
/// <remarks>See section 5.213.</remarks>
public enum AirspaceType : byte
{
    Unknown,
    /// <summary>
    /// Class C Airspace.
    /// </summary>
    Charlie,
    /// <summary>
    /// Control Area, ICAO Designation (CTA).
    /// </summary>
    ControlArea,
    /// <summary>
    /// Terminal Control Area, ICAO Designation (TMA or TCA).
    /// </summary>
    TerminalControlArea,
    /// <summary>
    /// Radar Zone or Radar Area.
    /// </summary>
    RadarZone,
    /// <summary>
    /// Class B Airspace.
    /// </summary>
    Bravo,
    /// <summary>
    /// Control Zone, ICAO Designation (CTR).
    /// </summary>
    ControlZone
}
