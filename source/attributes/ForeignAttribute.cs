namespace Arinc.Spec424.Attributes;

/// <summary>
/// Specifies a range of linking key to establish relationship.
/// </summary>
/// <inheritdoc/>
[AttributeUsage(AttributeTargets.Property)]
internal class ForeignAttribute(int start, int end) : RangeAttribute(start, end);
