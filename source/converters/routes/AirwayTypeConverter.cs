using Arinc424.Routing.Terms;

namespace Arinc424.Converters;

/// <summary>
/// Converter for <see cref="AirwayType"/>.
/// </summary>
internal abstract class AirwayTypeConverter : ICharConverter<AirwayTypeConverter, AirwayType>
{
    public static AirwayType Convert(char @char) => @char switch
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
