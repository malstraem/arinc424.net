namespace Arinc424.Procedures.Terms;

/**<summary>
<c>Route Type (RT TYPE)</c> -> <c>STAR Route Type Description</c> character.
</summary>
<remarks>See section 5.7, Table 5-7.</remarks>*/
[Char, Transform<ArrivalTypeConverter, ArrivalType>]
[Description("Route Type (RT TYPE) - STAR Route Type Description")]
public enum ArrivalType : byte
{
    Unknown,
    /**<summary>
    STAR Enroute Transition.
    </summary>*/
    [Map('1')] Enroute,
    /**<summary>
    STAR or STAR Common Route.
    </summary>*/
    [Map('2')] Common,
    /**<summary>
    STAR Runway Transition.
    </summary>*/
    [Map('3')] Runway,
    /**<summary>
    RNAV STAR Enroute Transition.
    </summary>*/
    [Map('4')] AreaNavigationEnroute,
    /**<summary>
    RNAV STAR or STAR Common Route.
    </summary>*/
    [Map('5')] AreaNavigationCommon,
    /**<summary>
    RNAV STAR Runway Transition.
    </summary>*/
    [Map('6')] AreaNavigationRunway,
    /**<summary>
    Profile Descent STAR Enroute Transition.
    </summary>*/
    [Map('7')] DescentEnroute,
    /**<summary>
    Profile Descent STAR or STAR Common Route.
    </summary>*/
    [Map('8')] DescentCommon,
    /**<summary>
    Profile Descent STAR Runway Transition.
    </summary>*/
    [Map('9')] DescentRunway,
    /**<summary>
    FMS STAR Enroute Transition.
    </summary>*/
    [Map('F')] FlightManagementEnroute,
    /**<summary>
    FMS STAR or STAR Common Route.
    </summary>*/
    [Map('M')] FlightManagementCommon,
    /**<summary>
    FMS STAR Runway Transition.
    </summary>*/
    [Map('S')] FlightManagementRunway,
    /**<summary>
    RNP STAR Enroute Transition.
    </summary>*/
    [Map('R')] PerformanceEnroute,
    /**<summary>
    RNP STAR or STAR Common Route.
    </summary>*/
    [Map('N')] PerformanceCommon,
    /**<summary>
    RNP STAR Runway Transition.
    </summary>*/
    [Map('P')] PerformanceRunway
}
