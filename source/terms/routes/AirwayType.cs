namespace Arinc.Spec424.Terms;

/// <summary>
/// <c>Route Type (RT TYPE)</c> -> <c>Airway Type</c>.
/// </summary>
/// <remarks>See table 5-2.</remarks>
public enum AirwayType : byte
{
    Unknown,
    /// <summary>
    /// Airline Airway (Tailored Data).
    /// </summary>
    Airline,
    /// <summary>
    /// Control.
    /// </summary>
    Control,
    /// <summary>
    /// Direct Route.
    /// </summary>
    Direct,
    /// <summary>
    /// Helicopter Airways.
    /// </summary>
    Helicopter,
    /// <summary>
    /// Officially Designated Airways, except RNAV, Helicopter Airways.
    /// </summary>
    Designated,
    /// <summary>
    /// RNAV Airways.
    /// </summary>
    AreaNavigation,
    /// <summary>
    /// Undesignated ATS Route.
    /// </summary>
    Undesignated,
    /// <summary>
    /// TACAN Airway.
    /// </summary>
    Tactical
}
