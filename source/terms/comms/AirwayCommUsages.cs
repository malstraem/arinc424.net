namespace Arinc424.Comms.Terms;

/// <summary>
/// <c>Service Indicator (SERV IND)</c> -> <c>Enroute</c>
/// </summary>
/// <remarks>See table 5-21.</remarks>
[Flags]
public enum AirwayCommUsages : ushort
{
    Unknown = 0,
    AeronauticalInfo = 1,
    FlightInfo = 1 << 1,
    AirGround = 1 << 2,
    Discrete = 1 << 3,
    Mandatory = 1 << 4,
    Secondary = 1 << 5,
    DirectionFinding = 1 << 6,
    NonEnglish = 1 << 7,
    Military = 1 << 8
}
