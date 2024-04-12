using Arinc424.Navigation.Terms;

namespace Arinc424.Converters;

internal abstract class LandingSystemTypeConverter : ICharConverter<LandingSystemTypeConverter, LandingSystemType>
{
    public static LandingSystemType Convert(char @char) => @char switch
    {
        '0' => LandingSystemType.NoGlideSlope,
        '1' => LandingSystemType.CategoryI,
        '2' => LandingSystemType.CategoryII,
        '3' => LandingSystemType.CategoryIII,
        'I' => LandingSystemType.InstrumentGuidance,
        'L' => LandingSystemType.DirectionalGlidSlope,
        'A' => LandingSystemType.DirectionalNoGlideSlope,
        'S' => LandingSystemType.SimplifiedGlidSlope,
        'F' => LandingSystemType.SimplifiedNoGlidSlope,
        _ => LandingSystemType.Unknown
    };
}
