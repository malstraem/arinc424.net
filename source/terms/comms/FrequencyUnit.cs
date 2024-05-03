namespace Arinc424.Comms.Terms;

/// <summary>
/// <c>Frequency Units (FREQ UNIT)</c> character.
/// </summary>
/// <remarks>See section 5.104.</remarks>
public enum FrequencyUnit : byte
{
    Unknown,
    Low,
    Medium,
    High,
    VeryHighSpacing100,
    VeryHighSpacing50,
    VeryHighSpacing25,
    VeryHighNonStandardSpacing,
    UltraHigh,
    Channel,
    Digital
}
