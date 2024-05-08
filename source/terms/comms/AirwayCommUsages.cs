namespace Arinc424.Comms.Terms;

/// <summary>
/// <c>Service Indicator (SERV IND)</c> -> <c>Enroute</c>
/// </summary>
/// <remarks>See table 5-21.</remarks>
[String, Flags]
public enum AirwayCommUsages : ushort
{
    Unknown = 0,
    [Map('A')] AeronauticalInfo = 1,
    [Map('F')] FlightInfo = 1 << 1,
    [Offset]
    [Map('A')] AirGround = 1 << 2,
    [Map('D')] Discrete = 1 << 3,
    [Map('M')] Mandatory = 1 << 4,
    [Map('S')] Secondary = 1 << 5,
    [Offset]
    [Map('D')] DirectionFinding = 1 << 6,
    [Map('L')] NonEnglish = 1 << 7,
    [Map('M')] Military = 1 << 8
}
