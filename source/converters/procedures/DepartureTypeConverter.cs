using Arinc424.Procedures.Terms;

namespace Arinc424.Converters;

internal abstract class DepartureTypeConverter : ICharConverter<DepartureTypeConverter, DepartureType>
{
    public static DepartureType Convert(char @char) => @char switch
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