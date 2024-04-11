using Arinc424.Procedures.Terms;

namespace Arinc424.Converters;

internal abstract class DepartureQualifiersConverter : IStringConverter<DepartureQualifiersConverter, DepartureQualifiers>
{
    public static DepartureQualifiers Convert(ReadOnlySpan<char> @string) => @string[0] switch
    {
        'D' => DepartureQualifiers.DistanceEquipment,
        'G' => DepartureQualifiers.GlobalNavigation,
        'R' => DepartureQualifiers.Radar,
        'H' => DepartureQualifiers.Helicopter,
        'F' => DepartureQualifiers.NavPerformance,
        _ => DepartureQualifiers.Unknown
    }
    | @string[1] switch
    {
        'C' => DepartureQualifiers.AreaNavigation,
        'D' => DepartureQualifiers.DatabaseAreaNavigation,
        'F' => DepartureQualifiers.FlightManagement,
        'G' => DepartureQualifiers.Conventional,
        _ => DepartureQualifiers.Unknown
    };
}
