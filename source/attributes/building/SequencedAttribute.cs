namespace Arinc424.Attributes;

/// <summary>
/// Specifies that the record is described by a sequence of strings and defines the range of the sequence number field.
/// </summary>
/// <inheritdoc/>
[AttributeUsage(AttributeTargets.Class)]
internal class SequencedAttribute(int start, int end) : RangeAttribute(start, end)
{
    internal SequencedAttribute(int index) : this(index, index) { }
}
