namespace Arinc424.Comms.Terms;

/// <summary>
/// <c>Service Indicator (SERV IND)</c> -> <c>Airport/Heliport</c> field.
/// </summary>
/// <remarks>See section 5.106, Table 5-20.</remarks>
[String, Flags, Decode<PortCommUsagesConverter, PortCommUsages>]
[Description("Service Indicator (SERV IND) - Airport/Heliport")]
public enum PortCommUsages : uint
{
    Unknown = 0,
    /// <summary>
    /// Airport Advisory Service (AAS).
    /// </summary>
    [Map('A')] Advisory = 1u,
    /// <summary>
    /// Community Aerodrome Radio Station (CARS).
    /// </summary>
    [Map('C')] Community = 1u << 1,
    /// <summary>
    /// Departure Service (other than Departure Control Unit).
    /// </summary>
    [Map('D')] Departure = 1u << 2,
    /// <summary>
    /// Flight Information Service (FIS).
    /// </summary>
    [Map('F')] FlightInfo = 1u << 3,
    /// <summary>
    /// Initial Contact (IC).
    /// </summary>
    [Map('I')] Initial = 1u << 4,
    /// <summary>
    /// Arrival Service (other than Arrival Control Unit).
    /// </summary>
    [Map('L')] Arrival = 1u << 5,
    /// <summary>
    /// Pre-Departure Clearance (Data Link  Service).
    /// </summary>
    [Map('P')] PreDepartureClearance = 1u << 6,
    /// <summary>
    /// Aerodrome Flight Information Service (AFIS).
    /// </summary>
    [Map('S')] AerodromeFlightInfo = 1u << 7,
    /// <summary>
    /// Terminal Area Control (other than dedicated Terminal Control Unit).
    /// </summary>
    [Map('T')] TerminalAreaControl = 1u << 8,
    /// <summary>
    /// Aerodrome Traffic Frequency (ATF).
    /// </summary>
    [Offset, Map('A')] AerodromeTraffic = 1u << 9,
    /// <summary>
    /// Common Traffic Advisory Frequency (CTAF).
    /// </summary>
    [Map('C')] CommonTraffic = 1u << 10,
    /// <summary>
    /// Mandatory Frequency (MF).
    /// </summary>
    [Map('M')] Mandatory = 1u << 11,
    /// <summary>
    /// Air/Air.
    /// </summary>
    [Map('R')] AirToAir = 1u << 12,
    /// <summary>
    /// Secondary Frequency.
    /// </summary>
    [Map('S')] Secondary = 1u << 13,
    /// <summary>
    /// Air/Ground.
    /// </summary>
    [Offset, Map('A')] AirGround = 1u << 14,
    /// <summary>
    /// VHF Direction Finding Service (VDF).
    /// </summary>
    [Map('D')] DirectionFinding = 1u << 15,
    /// <summary>
    /// Remote Communications Air to Ground (RCAG).
    /// </summary>
    [Map('G')] RemoteAirToGround = 1u << 16,
    /// <summary>
    /// Language other than English.
    /// </summary>
    [Map('L')] NotEnglish = 1u << 17,
    /// <summary>
    /// Military Use Frequency.
    /// </summary>
    [Map('M')] Military = 1u << 18,
    /// <summary>
    /// Pilot Controlled Light (PCL).
    /// </summary>
    [Map('P')] ControlledLight = 1u << 19,
    /// <summary>
    /// Remote Communications Outlet (RCO).
    /// </summary>
    [Map('R')] RemoteOutlet = 1u << 20
}
