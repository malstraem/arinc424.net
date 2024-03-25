namespace Arinc.Spec424.Attributes;

/// <summary>
/// Specifies the range of a field within an ARINC-424 string.
/// </summary>
/// <inheritdoc/>
[AttributeUsage(AttributeTargets.Property)]
internal class FieldAttribute(int start, int end) : RangeAttribute(start, end) { }
