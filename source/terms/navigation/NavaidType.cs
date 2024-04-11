namespace Arinc424.Navigation.Terms;

/// <summary>
/// First two characters of <c>NAVAID Class (CLASS)</c> field.
/// </summary>
/// <remarks>See section 5.35.</remarks>
[Flags]
public enum NavaidType : ushort
{
    Unknown = 0,
    Omnidirectional = 1,
    DistanceEquipment = 1 << 1,
    Tactical = 1 << 2,
    MilitaryTactical = 1 << 3,
    InstrumentLanding = 1 << 4,
    MicrowaveDistanceEquipmentN = 1 << 5,
    MicrowaveDistanceEquipmentP = 1 << 6,
    Nondirectional = 1 << 7,
    SABH = 1 << 8,
    Marine = 1 << 9,
    InnerMarker = 1 << 10,
    MiddleMarker = 1 << 11,
    OuterMarker = 1 << 12,
    BackMarker = 1 << 13
}
