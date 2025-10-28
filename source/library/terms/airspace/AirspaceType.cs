namespace Arinc424.Airspace.Terms;

/**<summary>
<c>Controlled Airspace Type (ARSP TYPE)</c> character.
</summary>
<remarks>See section 5.213.</remarks>*/
[Char, Transform<AirspaceTypeConverter, AirspaceType>]
[Description("Controlled Airspace Type (ARSP TYPE)")]
public enum AirspaceType : byte
{
    Unknown,
    /**<summary>
    Class C Airspace.
    </summary>*/
    [Map('A')] Charlie,
    /**<summary>
    Control Area, ICAO Designation (CTA).
    </summary>*/
    [Map('C')] ControlArea,
    /**<summary>
    Terminal Control Area, ICAO Designation (TMA or TCA).
    </summary>*/
    [Map('M')] TerminalControlArea,
    /**<summary>
    Radar Zone or Radar Area.
    </summary>*/
    [Map('R')] RadarZone,
    /**<summary>
    Class B Airspace.
    </summary>*/
    [Map('T')] Bravo,
    /**<summary>
    Radio Mandatory Zone (RMZ).
    </summary>*/
    [Map('U')] RadioMandatory,
    /**<summary>
    Transponder Mandatory Zone (TMZ).
    </summary>*/
    [Map('V')] TransponderMandatory,
    /**<summary>
    Control Zone, ICAO Designation (CTR).
    </summary>*/
    [Map('Z')] ControlZone
}
