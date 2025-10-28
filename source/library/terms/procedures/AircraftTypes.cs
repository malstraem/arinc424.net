namespace Arinc424.Procedures.Terms;

using T = AircraftTypes;

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

    [Map('D')]
    [Sum<T>(Echo, 'L')]
    Delta = 1 << 4,

    [Map('E')] Echo = 1 << 5,
    [Map('H')] Helicopter = 1 << 6,
    [Map('W')] Jet = 1 << 7,
    [Map('X')] NonJet = 1 << 8,
    [Map('Y')] Piston = 1 << 9,
    [Map('P')] Unlimited = 1 << 10,

    [Map('R')]
    [Sum<T>(Turboprop, 'Q')]
    Turbojet = 1 << 11,

    [Map('S')]
    [Sum<T>(Prop, 'U')]
    Turboprop = 1 << 12,

    [Map('T')] Prop = 1 << 13,
    [Map('V')] NonTurboJet = 1 << 14
}
