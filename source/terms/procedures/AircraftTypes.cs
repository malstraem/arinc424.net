namespace Arinc424.Procedures.Terms;

/// <summary>
/// <c>Procedure Design Aircraft Category or Type</c> character.
/// </summary>
/// <remarks>See section 5.301.</remarks>
[Flags]
public enum AircraftTypes : ushort
{
    Unknown = 0,
    /// <summary>
    /// Aircraft Category A only.
    /// </summary>
    CategoryA = 1,
    /// <summary>
    /// Aircraft Category B only.
    /// </summary>
    CategoryB = 1 << 1,
    /// <summary>
    /// Aircraft Category C only.
    /// </summary>
    CategoryC = 1 << 2,
    /// <summary>
    /// Aircraft Category D only.
    /// </summary>
    CategoryD = 1 << 3,
    /// <summary>
    /// Aircraft Category E only.
    /// </summary>
    CategoryE = 1 << 4,
    /// <summary>
    /// Aircraft Category H – (Helicopter) only.
    /// </summary>
    Helicopter = 1 << 5,
    /// <summary>
    /// Aircraft Type Not Limited.
    /// </summary>
    NotLimited = 1 << 6,
    /// <summary>
    /// Aircraft Type Turbojet only.
    /// </summary>
    Turbojet = 1 << 7,
    /// <summary>
    /// Aircraft Type Turboprop only.
    /// </summary>
    Turboprop = 1 << 8,
    /// <summary>
    /// Aircraft Type Prop only.
    /// </summary>
    Prop = 1 << 9,
}
