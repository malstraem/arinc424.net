namespace Arinc424.Procedures.Terms;

/// <summary>
/// <c>Procedure Design Aircraft Category or Type</c> character.
/// </summary>
/// <remarks>See section 5.301.</remarks>
[Char, Flags]
public enum AircraftTypes : ushort
{
    Unknown = 0,
    /// <summary>
    /// Aircraft Category A only.
    /// </summary>
    [Map('A')] Alpha = 1,
    /// <summary>
    /// Aircraft Category B only.
    /// </summary>
    [Map('B')] Bravo = 1 << 1,
    /// <summary>
    /// Aircraft Category C only.
    /// </summary>
    [Map('C')] Charlie = 1 << 2,
    /// <summary>
    /// Aircraft Category D only.
    /// </summary>
    [Map('D')] Delta = 1 << 3,
    /// <summary>
    /// Aircraft Category E only.
    /// </summary>
    [Map('E')] Echo = 1 << 4,
    /// <summary>
    /// Aircraft Categories A and B only.
    /// </summary>
    [Map('F')] AlphaBravo = Alpha | Bravo,
    /// <summary>
    /// Aircraft Categories C and D only.
    /// </summary>
    [Map('G')] CharlieDelta = Charlie | Delta,
    /// <summary>
    /// Aircraft Categories A, B and C only.
    /// </summary>
    [Map('I')] AlphaBravoCharlie = Alpha | Bravo | Charlie,
    /// <summary>
    /// Aircraft Categories A, B, C and D only.
    /// </summary>
    [Map('J')] AlphaBravoCharlieDelta = Alpha | Bravo | Charlie | Delta,
    /// <summary>
    /// Aircraft Categories A, B, C, D and E only.
    /// </summary>
    [Map('K')] AlphaBravoCharlieDeltaEcho = Alpha | Bravo | Charlie | Delta | Echo,
    /// <summary>
    /// Aircraft Categories D and E only.
    /// </summary>
    [Map('L')] DeltaEcho = Delta | Echo,
    /// <summary>
    /// Aircraft Category H – (Helicopter) only.
    /// </summary>
    [Map('H')] Helicopter = 1 << 5,
    /// <summary>
    /// Aircraft Type Not Limited.
    /// </summary>
    [Map('P')] NotLimited = 1 << 6,
    /// <summary>
    /// Aircraft Type Turbojet only.
    /// </summary>
    [Map('R')] Turbojet = 1 << 7,
    /// <summary>
    /// Aircraft Type Turboprop only.
    /// </summary>
    [Map('S')] Turboprop = 1 << 8,
    /// <summary>
    /// Aircraft Type Prop only.
    /// </summary>
    [Map('T')] Prop = 1 << 9,
    /// <summary>
    /// Aircraft Type Turboprop and Prop.
    /// </summary>
    [Map('U')] PropTurboProp = Turboprop | Prop
}
