namespace Arinc424.Procedures.Terms;

using T = ArrivalTypes;

/**<summary>
<c>Route Type (RT TYPE)</c> -> <c>STAR Route Type Description</c> character.
</summary>
<remarks>See section 5.7, Table 5-7.</remarks>*/
[Char, Flags, Transform<ArrivalTypesConverter, T>]
[Description("Route Type (RT TYPE) - STAR Route Type Description")]
public enum ArrivalTypes : byte
{
    Unknown = 0,
    /**<summary>
    STAR Enroute Transition.
    </summary>*/
    [Map('1')]
    [Sum<T>(Descent, '7')]
    [Sum<T>(Performance, 'R')]
    [Sum<T>(AreaNavigation, '4')]
    [Sum<T>(FlightManagement, 'F')]
    Enroute = 1,
    /**<summary>
    STAR Common Route.
    </summary>*/
    [Map('2')]
    [Sum<T>(Descent, '8')]
    [Sum<T>(Performance, 'N')]
    [Sum<T>(AreaNavigation, '5')]
    [Sum<T>(FlightManagement, 'M')]
    Common = 1 << 1,
    /**<summary>
    STAR Runway Transition.
    </summary>*/
    [Map('3')]
    [Sum<T>(Descent, '9')]
    [Sum<T>(Performance, 'P')]
    [Sum<T>(AreaNavigation, '6')]
    [Sum<T>(FlightManagement, 'S')]
    Runway = 1 << 2,
    /**<summary>
    Profile Descent STAR.
    </summary>*/
    Descent = 1 << 4,
    /**<summary>
    RNP STAR.
    </summary>*/
    Performance = 1 << 5,
    /**<summary>
    RNAV STAR.
    </summary>*/
    AreaNavigation = 1 << 6,
    /**<summary>
    FMS STAR.
    </summary>*/
    FlightManagement = 1 << 7
}
