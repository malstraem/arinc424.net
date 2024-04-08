namespace Arinc424.Airspace.Terms;

/// <summary>
/// <c>Restrictive Airspace Type (REST TYPE)</c> character.
/// </summary>
/// <remarks>See section 5.128.</remarks>
public enum RestrictiveType : byte
{
    Unknown,
    Alert,
    Caution,
    Danger,
    MilitaryOperations,
    NationalSecurity,
    Prohibited,
    Restricted,
    Training,
    Warning
}
