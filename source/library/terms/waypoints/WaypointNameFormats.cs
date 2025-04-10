namespace Arinc424.Waypoints.Terms;

/**<summary>
<c>Name Format Indicator (NAME IND)</c> field.
</summary>
<remarks>See section 5.196.</remarks>*/
[String, Flags, Decode<WaypointNameFormatsConverter, WaypointNameFormats>]
[Description("Name Format Indicator (NAME IND)")]
public enum WaypointNameFormats : uint
{
    Unknown = 0,
    /**<summary>
    Abeam Fix.
    </summary>*/
    [Map('A')] Abeam = 1u,
    /**<summary>
    Bearing and Distance Fix.
    </summary>*/
    [Map('B')] BearingDistance = 1u << 1,
    /**<summary>
    Airport Name as Fix.
    </summary>*/
    [Map('D')] AirportName = 1u << 2,
    /**<summary>
    FIR Fix.
    </summary>*/
    [Map('F')] FlightInfoRegion = 1u << 3,
    /**<summary>
    Phonetic Letter Name Fix.
    </summary>*/
    [Map('H')] PhoneticLetterName = 1u << 4,
    /**<summary>
    Airport Ident as Fix.
    </summary>*/
    [Map('I')] AirportIdentifier = 1u << 5,
    /**<summary>
    Latitude/Longitude Fix.
    </summary>*/
    [Map('L')] LatitudeLongitude = 1u << 6,
    /**<summary>
    Multiple Word Name Fix.
    </summary>*/
    [Map('M')] MultipleWordName = 1u << 7,
    /**<summary>
    Navaid Ident as Fix.
    </summary>*/
    [Map('N')] NavaidIdentifier = 1u << 8,
    /**<summary>
    Published Five - Letter - Name - Fix.
    </summary>*/
    [Map('P')] FiveLetterName = 1u << 9,
    /**<summary>
    Published Name Fix, less than five letters.
    </summary>*/
    [Map('Q')] LessFiveLetterName = 1u << 10,
    /**<summary>
    Published Name Fix, more than five letters.
    </summary>*/
    [Map('R')] MoreFiveLetterName = 1u << 11,
    /**<summary>
    Airport/Runway Related Fix.
    </summary>*/
    [Map('T')] AirportRunway = 1u << 12,
    /**<summary>
    UIR Fix.
    </summary>*/
    [Map('U')] UpperInfo = 1u << 13,
    /**<summary>
    VFR Checkpoint/Reporting Point as Fix.
    </summary>*/
    [Map('V')] Checkpoint = 1u << 14,
    /**<summary>
    Localizer Marker with officially published five - letter identifier.
    </summary>*/
    [Offset, Map('O')] LocalizerOfficialFive = 1u << 15,
    /**<summary>
    Localizer Marker without officially published five - letter identifier.
    </summary>*/
    [Map('M')] LocalizerUnofficialFive = 1u << 16
}
