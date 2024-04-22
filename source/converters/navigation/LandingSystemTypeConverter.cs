using Arinc424.Navigation.Terms;

namespace Arinc424.Converters;

internal abstract class LandingSystemTypeConverter : ICharConverter<LandingSystemTypeConverter, LandingSystemType>
{
    public static LandingSystemType Convert(char @char) => @char switch
    {
        '0' => LandingSystemType.NoGlideSlope,
        '1' => LandingSystemType.CategoryOne,
        '2' => LandingSystemType.CategoryTwo,
        '3' => LandingSystemType.CategoryThree,
        'I' => LandingSystemType.InstrumentGuidance,
        'L' => LandingSystemType.DirectionalGlideSlope,
        'A' => LandingSystemType.DirectionalNoGlideSlope,
        'S' => LandingSystemType.SimplifiedGlideSlope,
        'F' => LandingSystemType.SimplifiedNoGlideSlope,
        _ => LandingSystemType.Unknown
    };
}
