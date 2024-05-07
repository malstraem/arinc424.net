using System.ComponentModel;

using Arinc424.Attributes;

namespace Arinc424.Airspace.Terms;

/// <summary>
/// <c>Controlled Airspace Type (ARSP TYPE)</c> character.
/// </summary>
/// <remarks>See section 5.213.</remarks>
[Char, Description("Controlled Airspace Type (ARSP TYPE)")]
public enum AirspaceType : byte
{
    Unknown,
    /// <summary>
    /// Class C Airspace.
    /// </summary>
    [Map('A')]
    Charlie,
    /// <summary>
    /// Control Area, ICAO Designation (CTA).
    /// </summary>
    [Map('C')]
    ControlArea,
    /// <summary>
    /// Terminal Control Area, ICAO Designation (TMA or TCA).
    /// </summary>
    [Map('M')]
    TerminalControlArea,
    /// <summary>
    /// Radar Zone or Radar Area.
    /// </summary>
    [Map('R')]
    RadarZone,
    /// <summary>
    /// Class B Airspace.
    /// </summary>
    [Map('T')]
    Bravo,
    /// <summary>
    /// Control Zone, ICAO Designation (CTR).
    /// </summary>
    [Map('Z')]
    ControlZone
}
