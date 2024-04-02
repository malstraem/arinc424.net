namespace Arinc424.Procedures.Terms;

/// <summary>
/// <c>Path and Termination (PATH TERM)</c> field.
/// </summary>
/// <remarks>See section 5.21 and attachment 5.</remarks>
public enum LegType : byte
{
    Unknown,
    /// <summary>
    /// Initial Fix or IF Leg.
    /// </summary>
    Initial,
    /// <summary>
    /// Track to a Fix or TF Leg.
    /// </summary>
    TrackToFix,
    /// <summary>
    /// Course to a Fix or CF Leg.
    /// </summary>
    CourseToFix,
    /// <summary>
    /// Direct to a Fix or DF Leg.
    /// </summary>
    DirectToFix,
    /// <summary>
    ///  Fix to an Altitude or FA Leg.
    /// </summary>
    FixToAltitude,
    /// <summary>
    /// Track from a Fix to a Distance or FC Leg.
    /// </summary>
    FromFixToDistance,
    /// <summary>
    /// Track from a Fix to a DME Distance or FD Leg.
    /// </summary>
    FromFixToDme,
    /// <summary>
    /// From a Fix to a Manual termination or FM Leg.
    /// </summary>
    FromFixToManual,
    /// <summary>
    /// Course to an Altitude or CA Leg.
    /// </summary>
    CourseToAltitude,
    /// <summary>
    /// Course to a DME Distance or CD Leg.
    /// </summary>
    CourseToDme,
    /// <summary>
    /// Course to an Intercept or CI Leg.
    /// </summary>
    CourseToIntercept,
    /// <summary>
    /// Course to a Radial termination or CR Leg.
    /// </summary>
    CourseToRadial,
    /// <summary>
    /// Constant Radius Arc or RF Leg.
    /// </summary>
    ConstantRadiusArc,
    /// <summary>
    /// Arc to a Fix or AF Leg.
    /// </summary>
    ArcToFix,
    /// <summary>
    /// Heading to an Altitude termination or VA Leg.
    /// </summary>
    HeadingToAltitude,
    /// <summary>
    /// Heading to a DME Distance termination or VD Leg.
    /// </summary>
    HeadingToDme,
    /// <summary>
    /// Heading to an Intercept or VI Leg.
    /// </summary>
    HeadingToIntercept,
    /// <summary>
    /// Heading to a Manual termination or VM Leg.
    /// </summary>
    HeadingToManual,
    /// <summary>
    /// Heading to a Radial termination or VR Leg.
    /// </summary>
    HeadingToRadial,
    /// <summary>
    /// Procedure Turn or PI Leg.
    /// </summary>
    Turn,
    /// <summary>
    /// Altitude Termination or HA Leg.
    /// </summary>
    AltitudeTermination,
    /// <summary>
    /// Single circuit terminating at the fix or HF Leg.
    /// </summary>
    SingleCircuitTermination,
    /// <summary>
    /// Manual Termination or HM Leg.
    /// </summary>
    ManualTermination
}
