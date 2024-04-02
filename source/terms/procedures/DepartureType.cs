namespace Arinc424.Procedures.Terms;

/// <summary>
/// <c>Route Type (RT TYPE)</c> -> <c>SID Route Type Description</c> character.
/// </summary>
/// <remarks>See table 5-4.</remarks>
public enum DepartureType : byte
{
    Unknown,
    /// <summary>
    /// Engine Out SID.
    /// </summary>
    EngineOut,
    /// <summary>
    /// SID Runway Transition.
    /// </summary>
    RunwayTransition,
    /// <summary>
    /// SID or SID Common Route.
    /// </summary>
    Common,
    /// <summary>
    /// SID Enroute Transition.
    /// </summary>
    EnrouteTransition,
    /// <summary>
    /// RNP SID Runway Transition.
    /// </summary>
    PerformanceRunwayTransition,
    /// <summary>
    /// RNP SID or SID Common Route.
    /// </summary>
    PerformanceCommonRoute,
    /// <summary>
    /// RNP SID Enroute Transition.
    /// </summary>
    PerformanceEnrouteTransition,
    /// <summary>
    /// Vector SID Runway Transition.
    /// </summary>
    VectorRunwayTransition,
    /// <summary>
    /// Vector SID Enroute Transition.
    /// </summary>
    VectorEnrouteTransition
}
