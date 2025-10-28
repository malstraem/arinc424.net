namespace Arinc424.Procedures.Terms;

using T = ApproachTypes;

/**<summary>
<c>Route Type (RT TYPE)</c> -> <c>Approach Route Type Description</c> character.
</summary>
<remarks>See section 5.7, Table 5-8.</remarks>*/
[Char, Flags]
[Transform<ApproachTypesBeforeV23, T>]
[Transform<ApproachTypesConverter, T>(Start = Supplement.V23)]
[Description("Route Type (RT TYPE) - Approach Route Type Description")]
public enum ApproachTypes : uint
{
    Unknown = 0,
    /**<summary>
    Approach Transition.
    </summary>*/
    [Map('A')] Transition = 1,
    /**<summary>
    Localizer (LOC) Approach.
    </summary>*/
    [Map('L')]
    [Sum<T>(Backcourse, 'B')]
    [Sum<T>(Directioanl, 'X')]
    Localizer = 1 << 1,
    /**<summary>
    Non-Directional Beacon (NDB) Approach.
    </summary>*/
    [Map('N')]
    [Sum<T>(Equipment, 'Q')]
    Nondirect = 1 << 2,
    /**<summary>
    VOR Approach.
    </summary>*/
    [Map('V')]
    [Sum<T>(Equipment, 'D')]
    [Sum<T>(Equipment | Tactical, 'S')]
    Omnidirect = 1 << 3,
    /**<summary>
    TACAN Approach.
    </summary>*/
    [Map('T')] Tactical = 1 << 4,
    /**<summary>
    Flight Management System (FMS) Approach.
    </summary>*/
    [Map('F')] FlightManagement = 1 << 5,
    /**<summary>
    Instrument Guidance System (IGS) Approach.
    </summary>*/
    [Map('G')] InstrumentGuidance = 1 << 6,
    /**<summary>
    Instrument Landing System (ILS) Approach.
    </summary>*/
    [Map('I')] InstrumentLanding = 1 << 7,
    /**<summary>
    GNSS Landing System (GLS) Approach.
    </summary>*/
    [Map('J')] GlobalLanding = 1 << 8,
    /**<summary>
    Microwave Landing System (MLS) Approach.
    </summary>*/
    [Map('M')] MicrowaveLanding = 1 << 9,
    /**<summary>
    Global Positioning System (GPS) Approach.
    </summary>*/
    [Map('P')] GlobalPosition = 1 << 10,
    /**<summary>
    Area Navigation (RNAV) Approach.
    </summary>*/
    [Map('R')]
    [Sum<T>(Performance, 'H')]
    AreaNavigation = 1 << 11,
    /**<summary>
    Simplified Directional Facility (SDF) Approach.
    </summary>*/
    [Map('U')] Directioanl = 1 << 12,
    /**<summary>
    Approach Transition with TF Based Construction of RF Turns.
    </summary>*/
    [Map('Y')] BasedConstruction = 1 << 13,
    /**<summary>
    Missed Approach.
    </summary>*/
    [Map('Z')] Missed = 1 << 14,
    /**<summary>
    Localizer/Back Course Approach.
    </summary>*/
    Backcourse = 1 << 15,
    /**<summary>
    DME Approach.
    </summary>*/
    Equipment = 1 << 16,
    /**<summary>
    Required Navigation Performance (RNP) Approach.
    </summary>*/
    Performance = 1 << 17,
    /**<summary>
    Microwave Landing System (MLS), Type A Approach.
    </summary>*/
    TypeA = 1 << 18,
    /**<summary>
    Microwave Landing System (MLS), Type B and C Approach.
    </summary>*/
    TypeB = 1 << 19
}
