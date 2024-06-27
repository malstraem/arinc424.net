using Arinc424.Airspace.Terms;

namespace Arinc424.Converters;

internal abstract class RegionTypeConverter : ICharConverter<RegionType>
{
    public static RegionType Convert(char @char) => @char switch
    {
        'F' => RegionType.FlightInfo,
        'U' => RegionType.UpperInfo,
        'B' => RegionType.FlightInfo | RegionType.UpperInfo,
        _ => RegionType.Unknown
    };
}
