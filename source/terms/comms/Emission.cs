namespace Arinc424.Comms.Terms;

/// <summary>
/// <c>Signal Emission (SIG EM)</c> character.
/// </summary>
/// <remarks>See section 5.199.</remarks>
public enum Emission : byte
{
    Unknown,
    /// <summary>
    /// Double Sideband (A3).
    /// </summary>
    Double,
    /// <summary>
    /// Single sideband, reduced carrier (A3A).
    /// </summary>
    SingleReducedCarrier,
    /// <summary>
    /// Two Independent sidebands (A3B).
    /// </summary>
    TwoIndependent,
    /// <summary>
    /// Single sideband, full carrier (A3H).
    /// </summary>
    SingleFullCarrier,
    /// <summary>
    /// Single sideband, suppressed carrier (A3J).
    /// </summary>
    SingleSuppressedCarrier,
    /// <summary>
    /// Lower (single) sideband, carrier unknown.
    /// </summary>
    LowerUnknownCarrier,
    /// <summary>
    /// Upper (single) sideband, carrier unknown.
    /// </summary>
    UpperUnknownCarrier
}
