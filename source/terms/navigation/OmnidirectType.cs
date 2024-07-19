namespace Arinc424.Navigation.Terms;

/// <summary>
/// First two characters of <c>NAVAID Class (CLASS)</c> field, specific to <see cref="Omnidirectional"/>.
/// </summary>
/// <remarks>See section 5.35.</remarks>
[String, Flags, Decode<OmnidirectTypeConverter, OmnidirectType>]
[Description("NAVAID Class (CLASS) - Facility")]
public enum OmnidirectType : byte
{
    Unknown = 0,
    /// <summary>
    /// VOR.
    /// </summary>
    [Map('V')] Omnidirect = 1,
    /// <summary>
    /// DME.
    /// </summary>
    [Offset, Map('D')] DistanceEquipment = 1 << 1,
    /// <summary>
    /// TACAN (channels 17-59 and 70-126).
    /// </summary>
    [Map('T')] Tactical = 1 << 2,
    /// <summary>
    /// MIL TACAN (channels 1-16 and 60-69).
    /// </summary>
    [Map('M')] MilitaryTactical = 1 << 3,
    /// <summary>
    /// ILS/DME or ILS/TACAN.
    /// </summary>
    [Map('I')] InstrumentLanding = 1 << 4,
    /// <summary>
    /// MLS/DME/N.
    /// </summary>
    [Map('N')] NarrowMicrowave = 1 << 5,
    /// <summary>
    /// MLS/DME/P.
    /// </summary>
    [Map('P')] PrecisionMicrowave = 1 << 6
}
