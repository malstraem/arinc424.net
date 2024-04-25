using Arinc424.Comms.Terms;

namespace Arinc424.Converters;

internal abstract class DistanceLimitationConverter : ICharConverter<DistanceLimitationConverter, DistanceLimitation>
{
    public static DistanceLimitation Convert(char @char) => char.IsWhiteSpace(@char) ? DistanceLimitation.None : @char switch
    {
        '-' => DistanceLimitation.Out,
        '+' => DistanceLimitation.Beyond,
        _ => DistanceLimitation.Unknown
    };
}
