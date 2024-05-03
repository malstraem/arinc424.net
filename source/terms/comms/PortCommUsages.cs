namespace Arinc424.Comms.Terms;

/// <summary>
/// <c>Service Indicator (SERV IND)</c> -> <c>Airport/Heliport</c>
/// </summary>
/// <remarks>See table 5-20.</remarks>
[Flags]
public enum PortCommUsages : ushort
{
    Unknown = 0,
    /// <summary>
    /// Airport Advisory Service (AAS).
    /// </summary>
    Advisory = 1,
    /// <summary>
    /// Community Aerodrome Radio Station (CARS).
    /// </summary>
    Community = 1 << 1,
    /// <summary>
    /// Departure Service (other than Departure Control Unit).
    /// </summary>
    Departure = 1 << 2,
    /// <summary>
    /// Flight Information Service (FIS).
    /// </summary>
    FlightInfo = 1 << 3,
    /// <summary>
    /// Initial Contact (IC).
    /// </summary>
    Initial = 1 << 4,
    /// <summary>
    /// Arrival Service (other than Arrival Control Unit).
    /// </summary>
    Arrival = 1 << 5,
    /// <summary>
    /// Aerodrome Flight Information Service (AFIS).
    /// </summary>
    AerodromeFlightInfo = 1 << 6,
    /// <summary>
    /// Terminal Area Control (other than dedicated Terminal Control Unit).
    /// </summary>
    TerminalAreaControl = 1 << 7,
    /// <summary>
    /// Aerodrome Traffic Frequency (ATF).
    /// </summary>
    AerodromeTraffic = 1 << 8,
    /// <summary>
    /// Common Traffic Advisory Frequency (CTAF).
    /// </summary>
    CommonTraffic = 1 << 9,
    /// <summary>
    /// Mandatory Frequency (MF).
    /// </summary>
    Mandatory = 1 << 10,
    /// <summary>
    /// Secondary Frequency.
    /// </summary>
    Secondary = 1 << 11,
    /// <summary>
    /// VHF Direction Finding Service (VDF).
    /// </summary>
    DirectionFinding = 1 << 12,
    /// <summary>
    /// Language other than English.
    /// </summary>
    NotEnglish = 1 << 13,
    /// <summary>
    /// Military Use Frequency.
    /// </summary>
    Military = 1 << 14,
    /// <summary>
    /// Pilot Controlled Light (PCL).
    /// </summary>
    ControlledLight = 1 << 15
}
