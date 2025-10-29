namespace Arinc424.Procedures.Terms;

using T = AircraftTypes;

/**<summary>
<c> Procedure Design Aircraft Category or Type</c> character.
</summary>
<remarks>See section 5.301.</remarks>*/
[Char, Flags, Transform<AircraftTypesConverter, T>]
[Description("Procedure Design Aircraft Category or Type")]
public enum AircraftTypes : ushort
{
    Unknown = 0,

    [Map] Unspecified = 1,

    [Map('A')]
    [Sum<T>(Bravo, 'F')]
    [Sum<T>(Bravo | Charlie, 'I')]
    [Sum<T>(Bravo | Charlie | Delta, 'J')]
    [Sum<T>(Bravo | Charlie | Delta | Echo, 'K')]
    Alpha = 1 << 1,

    [Map('B')]
    [Sum<T>(Charlie, 'M')]
    [Sum<T>(Charlie | Delta | Echo, 'O')]
    Bravo = 1 << 2,

    [Map('C')]
    [Sum<T>(Delta, 'G')]
    [Sum<T>(Delta | Echo, 'N')]
    Charlie = 1 << 3,

    [Map('D'), Sum<T>(Echo, 'L')]
    Delta = 1 << 4,

    [Map('E')] Echo = 1 << 5,
    [Map('Y')] Piston = 1 << 6,
    [Map('W')] Jet = 1 << 7,
    [Map('R')] Turbojet = 1 << 8,
    [Map('T')] Prop = 1 << 9,

    [Map('S')]
    [Sum<T>(Turbojet, 'Q')]
    [Sum<T>(Prop, 'U')]
    Turboprop = 1 << 10,

    [Map('H')] Helicopter = 1 << 11,

    [Map('P')] Unlimited = Alpha | Bravo | Charlie | Delta | Echo | Piston | Jet | Turbojet | Prop | Turboprop | Helicopter,

    [Map('X')] NonJet = Piston | Turbojet | Prop | Turboprop,

    [Map('V')] NonTurboJet = Piston | Jet | Prop | Turboprop
}
