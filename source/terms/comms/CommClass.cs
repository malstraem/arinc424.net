namespace Arinc424.Comms.Terms;

/// <summary>
/// <c>Communications Class (Comm Class)</c> field.
/// </summary>
/// <remarks>See section 5.283.</remarks>
[String]
public enum CommClass : byte
{
    Unknown,
    /// <summary>
    /// Linked to an Information Region (FIR/UIR) for the purposes of providing control services to aircraft.
    /// </summary>
    [Map("LIRC")] RegionControl,
    /// <summary>
    /// Linked to an Information Region (FIR/UIR) for the purposes of providing information services to aircraft.
    /// </summary>
    [Map("LIRI")] RegionInfo,
    /// <summary>
    /// Used within an Information Region (FIR/UIR) for purposes other than control or information services and is not linked to that Region.
    /// </summary>
    [Map("USVC")] OtherInfoControl,
    /// <summary>
    /// Provide automated or broadcast services within an Information Region (FIR/UIR).
    /// </summary>
    [Map("ASVC")] Broadcast,
    /// <summary>
    /// Provide ATC services to aircraft within the terminal area of an airport.
    /// </summary>
    [Map("ATCF")] Terminal,
    /// <summary>
    /// Provide ATC services to aircraft on the ground at an airport.
    /// </summary>
    [Map("GNDF")] Ground,
    /// <summary>
    /// Provide services other than ATC functions on the ground or within the terminal area of an airport.
    /// </summary>
    [Map("AOTF")] OtherGroundTerminal,
    /// <summary>
    /// Provide automated or broadcast services to aircraft on the ground or with the terminal area of an airport.
    /// </summary>
    [Map("AFAC")] GroundTerminalBroadcast
}
