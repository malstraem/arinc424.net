namespace Arinc424.Navigation.Terms;

/// <summary>
/// <c>ILS/MLS/GLS Category (CAT)</c> character.
/// </summary>
/// <remarks>See section 5.80.</remarks>
public enum LandingSystemType : byte
{
    Unknown,
    /// <summary>
    /// ILS Localizer Only, No Glideslope.
    /// </summary>
    NoGlideSlope,
    /// <summary>
    /// ILS Localizer/MLS/GLS Category I.
    /// </summary>
    CategoryOne,
    /// <summary>
    /// ILS Localizer/MLS/GLS Category II.
    /// </summary>
    CategoryTwo,
    /// <summary>
    /// ILS Localizer/MLS/GLS Category III.
    /// </summary>
    CategoryThree,
    /// <summary>
    /// IGS Facility.
    /// </summary>
    InstrumentGuidance,
    /// <summary>
    /// LDA Facility with Glideslope.
    /// </summary>
    DirectionalGlideSlope,
    /// <summary>
    /// LDA Facility, no Glideslope.
    /// </summary>
    DirectionalNoGlideSlope,
    /// <summary>
    /// SDF Facility with Glideslope.
    /// </summary>
    SimplifiedGlideSlope,
    /// <summary>
    /// SDF Facility, no Glideslope.
    /// </summary>
    SimplifiedNoGlideSlope
}
