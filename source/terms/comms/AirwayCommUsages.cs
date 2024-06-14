namespace Arinc424.Comms.Terms;

/// <summary>
/// <c>Service Indicator (SERV IND)</c> -> <c>Enroute</c>.
/// </summary>
/// <remarks>See section 5.106, Table 5-21.</remarks>
[String, Flags, Decode<AirwayCommUsagesConverter, AirwayCommUsages>]
public enum AirwayCommUsages : ushort
{
    Unknown = 0,
    /// <summary>
    /// Aeronautical Enroute Information Service (AEIS).
    /// </summary>
    [Map('A')] AeronauticalInfo = 1,
    /// <summary>
    /// Flight Information Service (FIS).
    /// </summary>
    [Map('F')] FlightInfo = 1 << 1,
    /// <summary>
    /// Air/Ground.
    /// </summary>
    [Offset, Map('A')] AirGround = 1 << 2,
    /// <summary>
    /// Discrete Frequency.
    /// </summary>
    [Map('D')] Discrete = 1 << 3,
    /// <summary>
    /// Mandatory Frequency.
    /// </summary>
    [Map('M')] Mandatory = 1 << 4,
    /// <summary>
    /// Secondary Frequency.
    /// </summary>
    [Map('S')] Secondary = 1 << 5,
    /// <summary>
    /// VHF Direction Finding Service (VDF).
    /// </summary>
    [Offset, Map('D')] DirectionFinding = 1 << 6,
    /// <summary>
    /// Language other than English.
    /// </summary>
    [Map('L')] NonEnglish = 1 << 7,
    /// <summary>
    /// Military Use Frequency.
    /// </summary>
    [Map('M')] Military = 1 << 8
}
