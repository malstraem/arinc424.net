namespace Arinc424.Attributes;

/// <summary>
/// Specifies the range of a field within an ARINC-424 string.
/// </summary>
/// <param name="start">Left bound.</param>
/// <param name="end">Right bound.</param>
/// <remarks>Note that the bounds are exactly the same as those defined in the specification.</remarks>
internal abstract class RangeAttribute(int start, int end) : Attribute
{
    /// <summary>
    /// Field range within an string.
    /// </summary>
    internal Range Range { get; } = new Range(start - 1, end);
}
