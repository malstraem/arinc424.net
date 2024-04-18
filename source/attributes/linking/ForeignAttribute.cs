namespace Arinc424.Attributes;

/// <summary>
/// Specifies the range of the foreign key part to establish a relationship.
/// </summary>
/// <inheritdoc/>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal class ForeignAttribute(int start, int end) : RangeAttribute(start, end);
