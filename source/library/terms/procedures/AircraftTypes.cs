namespace Arinc424.Procedures.Terms;

using T = AircraftTypes;

/**<summary>
<c>Procedure Design Aircraft Category or Type</c> character.
</summary>
<remarks>See section 5.301.</remarks>*/
[Char, Flags, Transform<AircraftTypesConverter, T>]
[Description("Procedure Design Aircraft Category or Type")]
public enum AircraftTypes : ushort
{
    Unknown = 0,
    /**<summary>
    Aircraft Category/Type not provided.
    </summary>*/
    [Map] Unspecified = 1,
    /**<summary>
    Aircraft Category A.
    </summary>*/
    [Map('A')]
    [Sum<T>(Bravo, 'F')]
    [Sum<T>(Bravo | Charlie, 'I')]
    [Sum<T>(Bravo | Charlie | Delta, 'J')]
    [Sum<T>(Bravo | Charlie | Delta | Echo, 'K')]
    Alpha = 1 << 1,
    /**<summary>
    Aircraft Category B.
    </summary>*/
    [Map('B')]
    [Sum<T>(Charlie, 'M')]
    [Sum<T>(Charlie | Delta | Echo, 'O')]
    Bravo = 1 << 2,
    /**<summary>
    Aircraft Category C.
    </summary>*/
    [Map('C')]
    [Sum<T>(Delta, 'G')]
    [Sum<T>(Delta | Echo, 'N')]
    Charlie = 1 << 3,
    /**<summary>
    Aircraft Category D.
    </summary>*/
    [Map('D')]
    [Sum<T>(Echo, 'L')]
    Delta = 1 << 4,
    /**<summary>
    Aircraft Category E.
    </summary>*/
    [Map('E')] Echo = 1 << 5,
    /**<summary>
    Aircraft Category H – (Helicopter).
    </summary>*/
    [Map('H')] Helicopter = 1 << 6,
    /**<summary>
    Aircraft Type Jets.
    </summary>*/
    [Map('W')] Jet = 1 << 7,
    /**<summary>
    Aircraft Type Non Jets.
    </summary>*/
    [Map('X')] NonJet = 1 << 8,
    /**<summary>
    Aircraft Type Pistons.
    </summary>*/
    [Map('Y')] Piston = 1 << 9,
    /**<summary>
    Aircraft Type Not Limited.
    </summary>*/
    [Map('P')] Unlimited = 1 << 10,
    /**<summary>
    Aircraft Type Turbojet.
    </summary>*/
    [Map('R')]
    [Sum<T>(Turboprop, 'Q')]
    Turbojet = 1 << 11,
    /**<summary>
    Aircraft Type Turboprop.
    </summary>*/
    [Map('S')]
    [Sum<T>(Prop, 'U')]
    Turboprop = 1 << 12,
    /**<summary>
    Aircraft Type Prop.
    </summary>*/
    [Map('T')] Prop = 1 << 13,
    /**<summary>
    Aircraft Type Non-Turbojets.
    </summary>*/
    [Map('V')] NonTurboJet = 1 << 14
}
