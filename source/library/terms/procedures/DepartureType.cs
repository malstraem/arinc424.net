namespace Arinc424.Procedures.Terms;

/// <summary>
/// <c>Route Type (RT TYPE)</c> -> <c>SID Route Type Description</c> character.
/// </summary>
/// <remarks>See section 5.7, Table 5-5.</remarks>
[Char, Transform<DepartureTypeConverter, DepartureType>]
[Description("Route Type (RT TYPE) - SID Route Type Description")]
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
    [Map('1')] Runway,
    /// <summary>
    /// SID or SID Common Route.
    /// </summary>
    [Map('2')] Common,
    /// <summary>
    /// SID Enroute Transition.
    /// </summary>
    [Map('3')] Enroute,
    /// <summary>
    /// RNAV SID Runway Transition.
    /// </summary>
    [Map('4')] AreaNavigationRunway,
    /// <summary>
    /// RNAV SID or SID Common Route.
    /// </summary>
    [Map('5')] AreaNavigationCommon,
    /// <summary>
    /// RNAV SID Enroute Transition.
    /// </summary>
    [Map('6')] AreaNavigationEnroute,
    /// <summary>
    /// FMS SID Runway Transition.
    /// </summary>
    [Map('F')] FlightManagementRunway,
    /// <summary>
    /// FMS SID or SID Common Route.
    /// </summary>
    [Map('M')] FlightManagementCommon,
    /// <summary>
    /// FMS SID Enroute Transition.
    /// </summary>
    [Map('S')] FlightManagementEnroute,
    /// <summary>
    /// RNP SID Runway Transition.
    /// </summary>
    [Map('R')] PerformanceRunway,
    /// <summary>
    /// RNP SID or SID Common Route.
    /// </summary>
    [Map('N')] PerformanceCommon,
    /// <summary>
    /// RNP SID Enroute Transition.
    /// </summary>
    [Map('P')] PerformanceEnroute,
    /// <summary>
    /// Vector SID Runway Transition.
    /// </summary>
    [Map('T')] VectorRunway,
    /// <summary>
    /// Vector SID Enroute Transition.
    /// </summary>
    [Map('V')] VectorEnroute
}
