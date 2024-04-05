namespace Arinc424.Procedures.Terms;

/// <summary>
/// <c>Procedure Design Aircraft Category or Type</c> character.
/// </summary>
/// <remarks>See section 5.301.</remarks>
[Flags]
public enum AircraftTypes : uint
{
    Unknown = 0u,
    /// <summary>
    /// Aircraft Category A only.
    /// </summary>
    CategoryA = 1u,
    /// <summary>
    /// Aircraft Category B only.
    /// </summary>
    CategoryB = 1u << 1,
    /// <summary>
    /// Aircraft Category C only.
    /// </summary>
    CategoryC = 1u << 2,
    /// <summary>
    /// Aircraft Category D only.
    /// </summary>
    CategoryD = 1u << 3,
    /// <summary>
    /// Aircraft Category E only.
    /// </summary>
    CategoryE = 1u << 4,
    /// <summary>
    /// Aircraft Category H – (Helicopter) only.
    /// </summary>
    Helicopter = 1u << 5,
    /// <summary>
    /// Aircraft Type Not Limited.
    /// </summary>
    NotLimited = 1u << 6,
    /// <summary>
    /// Aircraft Type Turbojet only.
    /// </summary>
    Turbojet = 1u << 7,
    /// <summary>
    /// Aircraft Type Turboprop only.
    /// </summary>
    Turboprop = 1u << 8,
    /// <summary>
    /// Aircraft Type Prop only.
    /// </summary>
    Prop = 1u << 9,
}
