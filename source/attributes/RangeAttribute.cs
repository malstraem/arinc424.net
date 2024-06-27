namespace Arinc424.Attributes;

/// <summary>
/// Specifies the range of a field within an <c>ARINC-424</c> string.
/// </summary>
/// <remarks>Note that the bounds are exactly the same as those defined in the specification.</remarks>
internal abstract class RangeAttribute(int start, int end) : Attribute
{
    internal Range Range { get; } = new Range(start - 1, end);
}
