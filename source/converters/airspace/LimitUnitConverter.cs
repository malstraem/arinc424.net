using Arinc424.Airspace.Terms;

namespace Arinc424.Converters;

internal abstract class LimitUnitConverter : ICharConverter<LimitUnitConverter, LimitUnit>
{
    public static LimitUnit Convert(char @char) => @char switch
    {
        'M' => LimitUnit.Sea,
        'A' => LimitUnit.Ground,
        _ => LimitUnit.Unknown
    };
}
