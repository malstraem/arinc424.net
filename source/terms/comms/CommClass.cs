namespace Arinc424.Comms.Terms;

/// <summary>
/// <c>Communications Class (Comm Class)</c> field.
/// </summary>
/// <remarks>See section 5.283.</remarks>
public enum CommClass : byte
{
    Unknown,
    /// <summary>
    /// Linked to an Information Region (FIR/UIR) for the purposes of providing control services to aircraft.
    /// </summary>
    RegionControl,
    /// <summary>
    /// Linked to an Information Region (FIR/UIR) for the purposes of providing information services to aircraft.
    /// </summary>
    RegionInfo,
    /// <summary>
    /// Used within an Information Region (FIR/UIR) for purposes other than control or information services and is not linked to that Region.
    /// </summary>
    OtherInfoControl,
    /// <summary>
    /// Provide automated or broadcast services within an Information Region (FIR/UIR). 
    /// </summary>
    Broadcast,
    /// <summary>
    /// Provide ATC services to aircraft within the terminal area of an airport. 
    /// </summary>
    Terminal,
    /// <summary>
    /// Provide ATC services to aircraft on the ground at an airport. 
    /// </summary>
    Ground,
    /// <summary>
    /// Provide services other than  ATC functions on the ground or within the terminal area of an airport. 
    /// </summary>
    OtherGroundTerminal,
    /// <summary>
    /// Provide automated or broadcast services to aircraft on the ground or with the terminal area of an airport.
    /// </summary>
    GroundTerminalBroadcast
}
