namespace Arinc424.Procedures.Terms;

/// <summary>
/// <c>Route Type (RT TYPE)</c> -> <c>SID Type</c> character.
/// </summary>
/// <remarks>See section 5.7, Table 5-4.</remarks>
[Char, Transform<DepartureTypeConverter, DepartureType>]
[Description("Route Type (RT TYPE) - SID Type")]
public enum DepartureType : byte
{
    Unknown,
    /// <summary>
    /// Engine Out SID.
    /// </summary>
    [Map('0')] EngineOut,
    /// <summary>
    /// SID Runway Transition.
    /// </summary>
    [Map('1')] RunwayTransition,
    /// <summary>
    /// SID or SID Common Route.
    /// </summary>
    [Map('2')] Common,
    /// <summary>
    /// SID Enroute Transition.
    /// </summary>
    [Map('3')] EnrouteTransition,
    /// <summary>
    /// RNP SID Runway Transition.
    /// </summary>
    [Map('R')] PerformanceRunwayTransition,
    /// <summary>
    /// RNP SID or SID Common Route.
    /// </summary>
    [Map('N')] PerformanceCommonRoute,
    /// <summary>
    /// RNP SID Enroute Transition.
    /// </summary>
    [Map('P')] PerformanceEnrouteTransition,
    /// <summary>
    /// Vector SID Runway Transition.
    /// </summary>
    [Map('T')] VectorRunwayTransition,
    /// <summary>
    /// Vector SID Enroute Transition.
    /// </summary>
    [Map('V')] VectorEnrouteTransition
}
