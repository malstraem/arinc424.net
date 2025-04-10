namespace Arinc424.Routing.Terms;

/**<summary>
<c>Route Type (RT TYPE)</c> -> <c>Airway Type</c> character.
</summary>
<remarks>See table 5-2.</remarks>*/
[Char, Transform<AirwayTypeConverter, AirwayType>]
[Description("Route Type (RT TYPE) - Airway Type")]
public enum AirwayType : byte
{
    Unknown,
    /**<summary>
    Airline Airway (Tailored Data).
    </summary>*/
    [Map('A')] Airline,
    /**<summary>
    Control.
    </summary>*/
    [Map('C')] Control,
    /**<summary>
    Direct Route.
    </summary>*/
    [Map('D')] Direct,
    /**<summary>
    Helicopter Airways.
    </summary>*/
    [Map('H')] Helicopter,
    /**<summary>
    Officially Designated Airways,
    except RNAV, Helicopter Airways.
    </summary>*/
    [Map('O')] Designated,
    /**<summary>
    RNAV Airways.
    </summary>*/
    [Map('R')] AreaNavigation,
    /**<summary>
    Undesignated ATS Route.
    </summary>*/
    [Map('S')] Undesignated,
    /**<summary>
    TACAN Airway.
    </summary>*/
    [Map('T')] Tactical
}
