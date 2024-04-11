using Arinc424.Navigation.Terms;

namespace Arinc424.Converters;

internal abstract class NavaidInfoConverter : ICharConverter<NavaidInfoConverter, NavaidInfo>
{
    public static NavaidInfo Convert(char @char) => char.IsWhiteSpace(@char) ? NavaidInfo.Voice : @char switch
    {
        'D' => NavaidInfo.Biased,
        'A' => NavaidInfo.AutomaticBroadcast,
        'B' => NavaidInfo.ScheduledBroadcast,
        'W' => NavaidInfo.NoVoice,
        _ => NavaidInfo.Unknown
    };
}
