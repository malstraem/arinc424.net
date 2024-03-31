namespace Arinc.Spec424.Terms;

/// <summary>
/// <c>Boundary Code (BDY CODE)</c> character.
/// </summary>
/// <remarks>See section 5.18.</remarks>
public enum BoundaryCode : byte
{
    Unknown,
    UnitedStates,
    CanadaAlaska,
    Pacific,
    LatinAmerica,
    SouthAmerica,
    SouthPacific,
    Europe,
    EasternEurope,
    MiddleEastSouthAsia,
    Africa
}
