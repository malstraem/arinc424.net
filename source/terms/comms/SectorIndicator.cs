namespace Arinc424.Comms.Terms;

/// <summary>
/// <c>Multi-Sector Indicator (MSEC IND)</c> field.
/// </summary>
/// <remarks>See section 5.286.</remarks>
public enum SectorIndicator : byte
{
    Unknown,
    /// <summary>
    /// No defined sector data published for the service and frequency.
    /// </summary>
    Undefined,
    /// <summary>
    /// Multi-sector data is published in official government source for the service and frequency.
    /// </summary>
    Multi,
    /// <summary>
    /// Official government source has provided only a single defined sector for the service and frequency.
    /// </summary>
    Single
}
