namespace Arinc424.Attributes;

/**<summary>
Specifies <c>Airport/Heliport</c> identifier range.
</summary>*/
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
internal class PortAttribute(int left, int right) : RangeAttribute(left, right);
