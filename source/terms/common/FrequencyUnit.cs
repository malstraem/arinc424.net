namespace Arinc424;

/// <summary>
/// <c>Frequency Units (FREQ UNIT)</c> character.
/// </summary>
/// <remarks>See section 5.104.</remarks>
[Char, Description("Frequency Units (FREQ UNIT)")]
public enum FrequencyUnit : byte
{
    Unknown,
    /// <summary>
    /// Low Frequency.
    /// </summary>
    [Map('L')] Low,
    /// <summary>
    /// Medium Frequency.
    /// </summary>
    [Map('M')] Medium,
    /// <summary>
    /// High Frequency (3000 kHz to 30,000 kHz).
    /// </summary>
    [Map('H')] High,
    /// <summary>
    /// Very High Frequency 100 kHz spacing.
    /// </summary>
    [Map('K')] VeryHighSpacing100,
    /// <summary>
    /// Very High Frequency 50 kHz spacing.
    /// </summary>
    [Map('F')] VeryHighSpacing50,
    /// <summary>
    /// Very High Frequency 25 kHz spacing.
    /// </summary>
    [Map('T')] VeryHighSpacing25,
    /// <summary>
    /// Very High Frequency (30,000 kHz to 200 MHz) Non-standard spacing.
    /// </summary>
    [Map('V')] VeryHighNonStandardSpacing,
    /// <summary>
    /// Ultra High Frequency (200 MHz to 3000 MHz).
    /// </summary>
    [Map('U')] UltraHigh,
    /// <summary>
    /// Very High Frequency Communication Channel for 8.33kHz spacing.
    /// </summary>
    [Map('C')] Channel,
    /// <summary>
    /// Digital Service.
    /// </summary>
    [Map('D')] Digital
}
