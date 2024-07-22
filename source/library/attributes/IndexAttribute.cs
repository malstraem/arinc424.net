namespace Arinc424.Attributes;

/// <summary>
/// Specifies the index within an <c>ARINC-424</c> string.
/// </summary>
/// <remarks>Note that the index are exactly the same as those defined in the specification.</remarks>
internal abstract class IndexAttribute(int index, Supplement supplement) : SupplementAttribute(supplement)
{
    internal int Index { get; } = index - 1;
}
