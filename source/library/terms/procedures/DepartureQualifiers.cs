namespace Arinc424.Procedures.Terms;

/**<summary>
<c>Route Type (RT TYPE)</c> -> <c>SID Qualifiers</c> field.
</summary>
<remarks>See section 5.7, Table 5-5.</remarks>*/
[String, Flags, Decode<DepartureQualifiersConverter, DepartureQualifiers>]
[Description("Route Type (RT TYPE) - SID Qualifiers")]
public enum DepartureQualifiers : ushort
{
    Unknown = 0,
    /**<summary>
    DME required.
    </summary>*/
    [Map('D')] DistanceEquipment = 1,
    /**<summary>
    GNSS required.
    </summary>*/
    [Map('G')] GlobalNavigation = 1 << 1,
    /**<summary>
    Radar required.
    </summary>*/
    [Map('R')] Radar = 1 << 2,
    /**<summary>
    Helicopter SID from runway.
    </summary>*/
    [Map('H')] Helicopter = 1 << 3,
    /**<summary>
    RNP SAAAR/AR.
    </summary>*/
    [Map('F')] NavPerformance = 1 << 4,
    /**<summary>
    VOR/DME RNAV.
    </summary>*/
    [Offset, Map('C')] AreaNavigation = 1 << 5,
    /**<summary>
    Database supported RNAV.
    </summary>*/
    [Map('D')] DatabaseAreaNavigation = 1 << 6,
    /**<summary>
    FMS required.
    </summary>*/
    [Map('F')] FlightManagement = 1 << 7,
    /**<summary>
    Conventional Departures.
    </summary>*/
    [Map('G')] Conventional = 1 << 8
}
