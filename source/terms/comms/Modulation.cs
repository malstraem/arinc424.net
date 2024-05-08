namespace Arinc424.Comms.Terms;

/// <summary>
/// <c>Modulation (MODULN)</c> character.
/// </summary>
/// <remarks>See section 5.198.</remarks>
[Char, Description("Modulation (MODULN)")]
public enum Modulation : byte
{
    Unknown,
    /// <summary>
    /// Amplitude Modulated Frequency.
    /// </summary>
    [Map('A')] Amplitude,
    /// <summary>
    /// Frequency Modulated  Frequency.
    /// </summary>
    [Map('F')] Frequency
}
