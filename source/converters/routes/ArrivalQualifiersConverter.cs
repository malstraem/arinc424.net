using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Converters;

internal class ArrivalQualifiersConverter : IStringConverter<ArrivalQualifiersConverter, ArrivalQualifiers>
{
    public static ArrivalQualifiers Convert(string @string) => @string[0] switch
    {
        'D' => ArrivalQualifiers.DistanceEquipment,
        'R' => ArrivalQualifiers.Radar,
        'F' => ArrivalQualifiers.ConstantRadius,
        'G' => ArrivalQualifiers.GlobalNavigation,
        'H' => ArrivalQualifiers.Helicopter,
        'P' => ArrivalQualifiers.Continuous,
        _ => ArrivalQualifiers.Unknown
    }
    | @string[1] switch
    {
        'C' => ArrivalQualifiers.AreaNavigation,
        'D' => ArrivalQualifiers.DatabaseAreaNavigation,
        'F' => ArrivalQualifiers.FlightManagement,
        'G' => ArrivalQualifiers.Conventional,
        _ => ArrivalQualifiers.Unknown
    };
}
