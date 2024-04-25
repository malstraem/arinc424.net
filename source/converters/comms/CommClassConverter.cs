using Arinc424.Comms.Terms;

namespace Arinc424.Converters;

internal abstract class CommClassConverter : IStringConverter<CommClassConverter, CommClass>
{
    public static CommClass Convert(ReadOnlySpan<char> @string) => @string switch
    {
        "LIRC" => CommClass.RegionControl,
        "LIRI" => CommClass.RegionInfo,
        "USVC" => CommClass.OtherInfoControl,
        "ASVC" => CommClass.Broadcast,
        "ATCF" => CommClass.Terminal,
        "GNDF" => CommClass.Ground,
        "AOTF" => CommClass.OtherGroundTerminal,
        "AFAC" => CommClass.GroundTerminalBroadcast,
        _ => CommClass.Unknown
    };
}
