namespace Arinc424.Attributes;

/**<summary>
Specifies <c>ICAO Code</c> range.
</summary>*/
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
internal class IcaoAttribute(int left, int right) : RangeAttribute(left, right);
