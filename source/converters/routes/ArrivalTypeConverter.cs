using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Converters;

/// <summary>
/// Converter for <see cref="ArrivalType"/>.
/// </summary>
internal abstract class ArrivalTypeConverter : ICharConverter<ArrivalTypeConverter, ArrivalType>
{
    public static ArrivalType Convert(char @char) => @char switch
    {
        '1' => ArrivalType.EnrouteTransition,
        '2' => ArrivalType.Common,
        '3' => ArrivalType.RunwayTransition,
        'R' => ArrivalType.PerformanceEnrouteTransition,
        'N' => ArrivalType.PerformanceCommonRoute,
        'P' => ArrivalType.PerformanceRunwayTransition,
        _ => ArrivalType.Unknown
    };
}
