using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Converters;

internal class DepartureTypeConverter : ICharConverter
{
    public static object Convert(char @char) => @char switch
    {
        '0' => DepartureType.EngineOut,
        '1' => DepartureType.RunwayTransition,
        '2' => DepartureType.Common,
        '3' => DepartureType.EnrouteTransition,
        'R' => DepartureType.PerformanceRunwayTransition,
        'N' => DepartureType.PerformanceCommonRoute,
        'P' => DepartureType.PerformanceEnrouteTransition,
        'T' => DepartureType.VectorRunwayTransition,
        'V' => DepartureType.VectorEnrouteTransition,
        _ => DepartureType.Unknown
    };
}
