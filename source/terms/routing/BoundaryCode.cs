namespace Arinc424.Routing.Terms;

/// <summary>
/// <c>Boundary Code (BDY CODE)</c> character.
/// </summary>
/// <remarks>See section 5.18.</remarks>
[Char]
public enum BoundaryCode : byte
{
    Unknown,
    [Map('U')] UnitedStates,
    [Map('C')] CanadaAlaska,
    [Map('P')] Pacific,
    [Map('L')] LatinAmerica,
    [Map('S')] SouthAmerica,
    [Map('1')] SouthPacific,
    [Map('E')] Europe,
    [Map('2')] EasternEurope,
    [Map('M')] MiddleEastSouthAsia,
    [Map('A')] Africa
}
