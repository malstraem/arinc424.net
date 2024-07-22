namespace Arinc424.Navigation.Terms;

/// <summary>
/// <c>ILS/MLS/GLS Category (CAT)</c> character.
/// </summary>
/// <remarks>See section 5.80.</remarks>
[Char, Transform<LandingSystemTypeConverter, LandingSystemType>]
[Description("ILS/MLS/GLS Category (CAT)")]
public enum LandingSystemType : byte
{
    Unknown,
    /// <summary>
    /// ILS Localizer Only, No Glideslope.
    /// </summary>
    [Map('0')] NoGlideSlope,
    /// <summary>
    /// ILS Localizer/MLS/GLS Category I.
    /// </summary>
    [Map('1')] CategoryOne,
    /// <summary>
    /// ILS Localizer/MLS/GLS Category II.
    /// </summary>
    [Map('2')] CategoryTwo,
    /// <summary>
    /// ILS Localizer/MLS/GLS Category III.
    /// </summary>
    [Map('3')] CategoryThree,
    /// <summary>
    /// IGS Facility.
    /// </summary>
    [Map('I')] InstrumentGuidance,
    /// <summary>
    /// LDA Facility with Glideslope.
    /// </summary>
    [Map('L')] DirectionalGlideSlope,
    /// <summary>
    /// LDA Facility, no Glideslope.
    /// </summary>
    [Map('A')] DirectionalNoGlideSlope,
    /// <summary>
    /// SDF Facility with Glideslope.
    /// </summary>
    [Map('S')] SimplifiedGlideSlope,
    /// <summary>
    /// SDF Facility, no Glideslope.
    /// </summary>
    [Map('F')] SimplifiedNoGlideSlope
}
