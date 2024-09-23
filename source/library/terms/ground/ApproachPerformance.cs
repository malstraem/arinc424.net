namespace Arinc424.Ground.Terms;

/// <summary>
/// <c>Approach Performance Designator (APD)</c> character.
/// </summary>
/// <remarks>See section 5.258.</remarks>
[Char, Flags, Transform<ApproachPerformanceConverter, ApproachPerformance>]
[Description("Approach Performance Designator (APD)")]
public enum ApproachPerformance : byte
{
    Unknown = 0,
    /// <summary>
    /// GAST A.
    /// </summary>
    Alpha = 1,
    /// <summary>
    /// GAST B.
    /// </summary>
    Bravo = 1 << 1,
    /// <summary>
    /// GAST A or GAST B.
    /// </summary>
    [Map('0')] AlphaBravo = Alpha | Bravo,
    /// <summary>
    /// GAST C.
    /// </summary>
    [Map('1')] Charlie = 1 << 2,
    /// <summary>
    /// GAST D.
    /// </summary>
    Delta = 1 << 3,
    /// <summary>
    /// GAST C or GAST D.
    /// </summary>
    [Map('2')] CharlieDelta = Charlie | Delta
}
