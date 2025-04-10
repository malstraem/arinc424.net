namespace Arinc424.Navigation.Terms;

/**<summary>
Third character of <c>NAVAID Class (CLASS)</c> field,
specific to <see cref="Omnidirectional"/>.
</summary>
<remarks>See section 5.35.</remarks>*/
[Char, Transform<OmnidirectCoverageConverter, OmnidirectCoverage>]
[Description("NAVAID Class (CLASS) - Coverage")]
public enum OmnidirectCoverage : byte
{
    Unknown,
    /**<summary>
    Generally usable within 25NM of the facility and below 12000 feet.
    </summary>*/
    [Map('T')] Terminal,
    /**<summary>
    Generally usable within 40NM of the facility and up to 18000 feet.
    </summary>*/
    [Map('L')] LowAltitude,
    /**<summary>
    Generally usable Within 130NM of the facility and up to 60000 feet.
    </summary>*/
    [Map('H')] HighAltitude,
    /**<summary>
    Coverage not defined by government source.
    </summary>*/
    [Map('U')] Undefined,
    /**<summary>
    Full TACAN facility frequency-paired and operating
    with the same identifier as an ILS Localizer.
    </summary>*/
    [Map('C')] Tactical
}
