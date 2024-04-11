using Arinc424.Procedures.Terms;

namespace Arinc424.Converters;

internal abstract class SpeedLimitTypeConverter : ICharConverter<SpeedLimitTypeConverter, SpeedLimitType>
{
    public static SpeedLimitType Convert(char @char) => char.IsWhiteSpace(@char) ? SpeedLimitType.Mandatory : @char switch
    {
        '+' => SpeedLimitType.Minimum,
        '-' => SpeedLimitType.Maximum,
        _ => SpeedLimitType.Unknown
    };
}
