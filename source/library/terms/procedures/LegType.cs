namespace Arinc424.Procedures.Terms;

/**<summary>
<c>Path and Termination (PATH TERM)</c> field.
</summary>
<remarks>See section 5.21.</remarks>*/
[String, Decode<LegTypeConverter, LegType>]
[Description("Path and Termination (PATH TERM)")]
public enum LegType : byte
{
    Unknown,
    /**<summary>
    Initial Fix or IF Leg.
    </summary>*/
    [Map("IF")] Initial,
    /**<summary>
    Track to a Fix or TF Leg.
    </summary>*/
    [Map("TF")] TrackToFix,
    /**<summary>
    Course to a Fix or CF Leg.
    </summary>*/
    [Map("CF")] CourseToFix,
    /**<summary>
    Direct to a Fix or DF Leg.
    </summary>*/
    [Map("DF")] DirectToFix,
    /**<summary>
     Fix to an Altitude or FA Leg.
    </summary>*/
    [Map("FA")] FixToAltitude,
    /**<summary>
    Track from a Fix to a Distance or FC Leg.
    </summary>*/
    [Map("FC")] FromFixToDistance,
    /**<summary>
    Track from a Fix to a DME Distance or FD Leg.
    </summary>*/
    [Map("FD")] FromFixToDme,
    /**<summary>
    From a Fix to a Manual termination or FM Leg.
    </summary>*/
    [Map("FM")] FromFixToManual,
    /**<summary>
    Course to an Altitude or CA Leg.
    </summary>*/
    [Map("CA")] CourseToAltitude,
    /**<summary>
    Course to a DME Distance or CD Leg.
    </summary>*/
    [Map("CD")] CourseToDme,
    /**<summary>
    Course to an Intercept or CI Leg.
    </summary>*/
    [Map("CI")] CourseToIntercept,
    /**<summary>
    Course to a Radial termination or CR Leg.
    </summary>*/
    [Map("CR")] CourseToRadial,
    /**<summary>
    Constant Radius Arc or RF Leg.
    </summary>*/
    [Map("RF")] ConstantRadiusArc,
    /**<summary>
    Arc to a Fix or AF Leg.
    </summary>*/
    [Map("AF")] ArcToFix,
    /**<summary>
    Heading to an Altitude termination or VA Leg.
    </summary>*/
    [Map("VA")] HeadingToAltitude,
    /**<summary>
    Heading to a DME Distance termination or VD Leg.
    </summary>*/
    [Map("VD")] HeadingToDme,
    /**<summary>
    Heading to an Intercept or VI Leg.
    </summary>*/
    [Map("VI")] HeadingToIntercept,
    /**<summary>
    Heading to a Manual termination or VM Leg.
    </summary>*/
    [Map("VM")] HeadingToManual,
    /**<summary>
    Heading to a Radial termination or VR Leg.
    </summary>*/
    [Map("VR")] HeadingToRadial,
    /**<summary>
    Procedure Turn or PI Leg.
    </summary>*/
    [Map("PI")] Turn,
    /**<summary>
    Altitude Termination or HA Leg.
    </summary>*/
    [Map("HA")] AltitudeTermination,
    /**<summary>
    Single circuit terminating at the fix or HF Leg.
    </summary>*/
    [Map("HF")] SingleCircuitTermination,
    /**<summary>
    Manual Termination or HM Leg.
    </summary>*/
    [Map("HM")] ManualTermination
}
