namespace Arinc424.Ground.Terms;

using T = ApproachPerformance;

/**<summary>
<c>Approach Performance Designator (APD)</c> character.
</summary>
<remarks>See section 5.258.</remarks>*/
[Char, Flags, Transform<ApproachPerformanceConverter, T>]
[Description("Approach Performance Designator (APD)")]
public enum ApproachPerformance : byte
{
    Unknown = 0,
    /**<summary>
    GAST A.
    </summary>*/
    [Sum<T>(Bravo, '0')]
    Alpha = 1,
    /**<summary>
    GAST B.
    </summary>*/
    Bravo = 1 << 1,
    /**<summary>
    GAST C.
    </summary>*/
    [Map('1')]
    [Sum<T>(Delta, '2')]
    Charlie = 1 << 2,
    /**<summary>
    GAST D.
    </summary>*/
    Delta = 1 << 3
}
