namespace Arinc424.Comms.Terms;

/// <summary>
/// <c>Modulation (MODULN)</c> character.
/// </summary>
/// <remarks>See section 5.198.</remarks>
public enum Modulation : byte
{
    Unknown,
    /// <summary>
    /// Amplitude Modulated Frequency.
    /// </summary>
    Amplitude,
    /// <summary>
    /// Frequency Modulated  Frequency.
    /// </summary>
    Frequency
}
