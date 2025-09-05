namespace Arinc424.Attributes;

/**<summary>
Specifies <see cref="IIdentity.Identifier"/> range.
</summary>
<inheritdoc/>*/
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
internal class IdAttribute(int left, int right) : RangeAttribute(left, right)
{
    internal KeyInfo GetInfo(IcaoAttribute? icao, PortAttribute? port)
        => new(Range, icao?.Range, port?.Range);
}
