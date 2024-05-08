namespace Arinc424.Comms.Terms;

/// <summary>
/// <c>Signal Emission (SIG EM)</c> character.
/// </summary>
/// <remarks>See section 5.199.</remarks>
[Char, Description("Signal Emission (SIG EM)")]
public enum Emission : byte
{
    Unknown,
    /// <summary>
    /// Double Sideband (A3).
    /// </summary>
    [Map('3')] Double,
    /// <summary>
    /// Single sideband, reduced carrier (A3A).
    /// </summary>
    [Map('A')] SingleReducedCarrier,
    /// <summary>
    /// Two Independent sidebands (A3B).
    /// </summary>
    [Map('B')] TwoIndependent,
    /// <summary>
    /// Single sideband, full carrier (A3H).
    /// </summary>
    [Map('H')] SingleFullCarrier,
    /// <summary>
    /// Single sideband, suppressed carrier (A3J).
    /// </summary>
    [Map('J')] SingleSuppressedCarrier,
    /// <summary>
    /// Lower (single) sideband, carrier unknown.
    /// </summary>
    [Map('L')] LowerUnknownCarrier,
    /// <summary>
    /// Upper (single) sideband, carrier unknown.
    /// </summary>
    [Map('U')] UpperUnknownCarrier
}
