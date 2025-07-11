namespace Arinc424.Attributes;

/**<summary>
Specifies <see cref="Icao"/> range.
</summary>*/
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
internal class IcaoAttribute(int left, int right) : RangeAttribute(left, right);
