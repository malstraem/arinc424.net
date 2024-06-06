namespace Arinc424.Comms.Terms;

/// <summary>
/// <c>Service Indicator (SERV IND)</c> -> <c>Airport/Heliport</c> field.
/// </summary>
/// <remarks>See section 5.106, Table 5-20.</remarks>
[String, Flags, Decode<PortCommUsagesConverter, PortCommUsages>]
public enum PortCommUsages : ushort
{
    Unknown = 0,
    /// <summary>
    /// Airport Advisory Service (AAS).
    /// </summary>
    [Map('A')] Advisory = 1,
    /// <summary>
    /// Community Aerodrome Radio Station (CARS).
    /// </summary>
    [Map('C')] Community = 1 << 1,
    /// <summary>
    /// Departure Service (other than Departure Control Unit).
    /// </summary>
    [Map('D')] Departure = 1 << 2,
    /// <summary>
    /// Flight Information Service (FIS).
    /// </summary>
    [Map('F')] FlightInfo = 1 << 3,
    /// <summary>
    /// Initial Contact (IC).
    /// </summary>
    [Map('I')] Initial = 1 << 4,
    /// <summary>
    /// Arrival Service (other than Arrival Control Unit).
    /// </summary>
    [Map('L')] Arrival = 1 << 5,
    /// <summary>
    /// Aerodrome Flight Information Service (AFIS).
    /// </summary>
    [Map('S')] AerodromeFlightInfo = 1 << 6,
    /// <summary>
    /// Terminal Area Control (other than dedicated Terminal Control Unit).
    /// </summary>
    [Map('T')] TerminalAreaControl = 1 << 7,

    [Offset]
    /// <summary>
    /// Aerodrome Traffic Frequency (ATF).
    /// </summary>
    [Map('A')] AerodromeTraffic = 1 << 8,
    /// <summary>
    /// Common Traffic Advisory Frequency (CTAF).
    /// </summary>
    [Map('C')] CommonTraffic = 1 << 9,
    /// <summary>
    /// Mandatory Frequency (MF).
    /// </summary>
    [Map('M')] Mandatory = 1 << 10,
    /// <summary>
    /// Secondary Frequency.
    /// </summary>
    [Map('S')] Secondary = 1 << 11,

    [Offset]
    /// <summary>
    /// VHF Direction Finding Service (VDF).
    /// </summary>
    [Map('D')] DirectionFinding = 1 << 12,
    /// <summary>
    /// Language other than English.
    /// </summary>
    [Map('L')] NotEnglish = 1 << 13,
    /// <summary>
    /// Military Use Frequency.
    /// </summary>
    [Map('M')] Military = 1 << 14,
    /// <summary>
    /// Pilot Controlled Light (PCL).
    /// </summary>
    [Map('P')] ControlledLight = 1 << 15
}
