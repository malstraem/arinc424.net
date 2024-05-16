namespace Arinc424.Procedures.Terms;

/// <summary>
/// <c>Route Type (RT TYPE)</c> -> <c>STAR Route Type Description</c> character.
/// </summary>
/// <remarks>See section 5.7, Table 5-6.</remarks>
[Char]
public enum ArrivalType : byte
{
    Unknown,
    /// <summary>
    /// STAR Enroute Transition.
    /// </summary>
    [Map('1')] EnrouteTransition,
    /// <summary>
    /// STAR or STAR Common Route.
    /// </summary>
    [Map('2')] Common,
    /// <summary>
    /// STAR Runway Transition.
    /// </summary>
    [Map('3')] RunwayTransition,
    /// <summary>
    /// RNP STAR Enroute Transition.
    /// </summary>
    [Map('R')] PerformanceEnrouteTransition,
    /// <summary>
    /// RNP STAR or STAR Common Route.
    /// </summary>
    [Map('N')] PerformanceCommonRoute,
    /// <summary>
    /// RNP STAR Runway Transition.
    /// </summary>
    [Map('P')] PerformanceRunwayTransition
}
