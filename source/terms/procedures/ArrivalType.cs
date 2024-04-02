namespace Arinc424.Procedures.Terms;

/// <summary>
/// <c>Route Type (RT TYPE)</c> -> <c>STAR Route Type Description</c> character.
/// </summary>
/// <remarks>See table 5-6.</remarks>
public enum ArrivalType : byte
{
    Unknown,
    /// <summary>
    /// STAR Enroute Transition.
    /// </summary>
    EnrouteTransition,
    /// <summary>
    /// STAR or STAR Common Route.
    /// </summary>
    Common,
    /// <summary>
    /// STAR Runway Transition.
    /// </summary>
    RunwayTransition,
    /// <summary>
    /// RNP STAR Enroute Transition.
    /// </summary>
    PerformanceEnrouteTransition,
    /// <summary>
    /// RNP STAR or STAR Common Route.
    /// </summary>
    PerformanceCommonRoute,
    /// <summary>
    /// RNP STAR Runway Transition.
    /// </summary>
    PerformanceRunwayTransition
}
