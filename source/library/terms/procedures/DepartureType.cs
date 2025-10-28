namespace Arinc424.Procedures.Terms;

using T = DepartureTypes;

/**<summary>
<c>Route Type (RT TYPE)</c> -> <c>SID Route Type Description</c> character.
</summary>
<remarks>See section 5.7, Table 5-5.</remarks>*/
[Char, Flags, Transform<DepartureTypesConverter, T>]
[Description("Route Type (RT TYPE) - SID Route Type Description")]
public enum DepartureTypes : byte
{
    Unknown = 0,
    /**<summary>
    Engine Out SID.
    </summary>*/
    [Map('0')] EngineOut = 1,
    /**<summary>
    SID Runway Transition.
    </summary>*/
    [Map('1')]
    [Sum<T>(AreaNavigation, '4')]
    [Sum<T>(FlightManagement, 'F')]
    [Sum<T>(Performance, 'R')]
    [Sum<T>(Vector, 'T')]
    Runway = 1 << 1,
    /**<summary>
    SID or SID Common Route.
    </summary>*/
    [Map('2')]
    [Sum<T>(AreaNavigation, '5')]
    [Sum<T>(FlightManagement, 'M')]
    [Sum<T>(Performance, 'N')]
    Common = 1 << 2,
    /**<summary>
    SID Enroute Transition.
    </summary>*/
    [Map('3')]
    [Sum<T>(AreaNavigation, '6')]
    [Sum<T>(FlightManagement, 'S')]
    [Sum<T>(Performance, 'P')]
    [Sum<T>(Vector, 'V')]
    Enroute = 1 << 3,
    /**<summary>
    RNAV SID.
    </summary>*/
    AreaNavigation = 1 << 4,
    /**<summary>
    FMS SID.
    </summary>*/
    FlightManagement = 1 << 5,
    /**<summary>
    RNP SID.
    </summary>*/
    Performance = 1 << 6,
    /**<summary>
    Vector SID.
    </summary>*/
    Vector = 1 << 7
}
