using Arinc424.Comms.Terms;

namespace Arinc424.Converters;

internal abstract class SectorIndicatorConverter : ICharConverter<SectorIndicatorConverter, SectorIndicator>
{
    public static SectorIndicator Convert(char @char) => char.IsWhiteSpace(@char) ? SectorIndicator.Undefined : @char switch
    {
        'Y' => SectorIndicator.Multi,
        'N' => SectorIndicator.Single,
        _ => SectorIndicator.Unknown
    };
}
