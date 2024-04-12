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
    CategoryI,
    /// <summary>
    /// ILS Localizer/MLS/GLS Category II.
    /// </summary>
    CategoryII,
    /// <summary>
    /// ILS Localizer/MLS/GLS Category III.
    /// </summary>
    CategoryIII,
    /// <summary>
    /// IGS Facility.
    /// </summary>
    InstrumentGuidance,
    /// <summary>
    /// LDA Facility with Glideslope.
    /// </summary>
    DirectionalGlidSlope,
    /// <summary>
    /// LDA Facility, no Glideslope.
    /// </summary>
    DirectionalNoGlideSlope,
    /// <summary>
    /// SDF Facility with Glideslope.
    /// </summary>
    SimplifiedGlidSlope,
    /// <summary>
    /// SDF Facility, no Glideslope.
    /// </summary>
    SimplifiedNoGlidSlope
}
