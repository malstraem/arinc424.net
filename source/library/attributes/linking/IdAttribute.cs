namespace Arinc424.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
internal sealed class IdAttribute(int left, int right) : RangeAttribute(left, right)
{
    internal KeyInfo GetInfo(IcaoAttribute? icao, PortAttribute? port) => new(Range, icao?.Range, port?.Range);
}
