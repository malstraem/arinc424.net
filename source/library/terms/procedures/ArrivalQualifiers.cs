namespace Arinc424.Procedures.Terms;

/**<summary>
<c>Route Type (RT TYPE)</c> -> <c>STAR Qualifiers</c> field.
</summary>
<remarks>See section 5.7, Table 5-6.</remarks>*/
[String, Flags, Decode<ArrivalQualifiersConverter, ArrivalQualifiers>]
[Description("Route Type (RT TYPE) - STAR Qualifiers")]
public enum ArrivalQualifiers : ushort
{
    Unknown = 0,
    /**<summary>
    DME required.
    </summary>*/
    [Map('D')] DistanceEquipment = 1,
    /**<summary>
    Radar required.
    </summary>*/
    [Map('R')] Radar = 1 << 1,
    /**<summary>
    RF Leg capability required.
    </summary>*/
    [Map('F')] ConstantRadius = 1 << 2,
    /**<summary>
    GNSS required.
    </summary>*/
    [Map('G')] GlobalNavigation = 1 << 3,
    /**<summary>
    Helicopter STAR to Runway.
    </summary>*/
    [Map('H')] Helicopter = 1 << 4,
    /**<summary>
    Continuous Descent STAR.
    </summary>*/
    [Map('P')] Continuous = 1 << 5,
    /**<summary>
    VOR/DME RNAV.
    </summary>*/
    [Offset, Map('C')] AreaNavigation = 1 << 6,
    /**<summary>
    Database supported RNAV.
    </summary>*/
    [Map('D')] DatabaseAreaNavigation = 1 << 7,
    /**<summary>
    FMS required.
    </summary>*/
    [Map('F')] FlightManagement = 1 << 8,
    /**<summary>
    Conventional Arrivals.
    </summary>*/
    [Map('G')] Conventional = 1 << 9
}
