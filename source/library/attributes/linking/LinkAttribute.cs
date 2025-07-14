using System.Reflection;

namespace Arinc424.Attributes;

using Linking;

internal abstract class LinkAttribute(int left, int right) : RangeAttribute(left, right)
{
    protected KeyInfo GetInfo(IcaoAttribute? icao, PortAttribute? port) => new(Range, icao?.Range, port?.Range);

    internal abstract Link<TRecord> GetLink<TRecord>
    (
        PropertyInfo property,
        Supplement supplement,
        IcaoAttribute? icao,
        PortAttribute? port
    )
    where TRecord : Record424;
}
