namespace Arinc424.Attributes;

/**<summary>
Specifies the range of a field within an <c>ARINC-424</c> string.
</summary>
<remarks>Note that the bounds are exactly the same as those defined in the specification.</remarks>*/
public abstract class RangeAttribute(int left, int right) : SupplementAttribute
{
    internal Range Range { get; } = new Range(left - 1, right);
}
