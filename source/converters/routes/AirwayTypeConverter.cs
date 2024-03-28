using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Converters;

internal class AirwayTypeConverter : ICharConverter
{
    public static object Convert(char @char) => @char switch
    {
        'A' => AirwayType.Airline,
        'C' => AirwayType.Control,
        'D' => AirwayType.Direct,
        'H' => AirwayType.Helicopter,
        'O' => AirwayType.Designated,
        'R' => AirwayType.AreaNavigation,
        'S' => AirwayType.Undesignated,
        'T' => AirwayType.Tactical,
        _ => AirwayType.Unknown
    };
}
