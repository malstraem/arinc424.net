namespace Arinc424.Attributes;

/// <summary>
/// Specifies that the property is a part of primary key to establish a relationship.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
internal class PrimaryAttribute(int start = 0, int end = 0) : Attribute
{
    internal Range? Range = start is 0 || end is 0 ? null : new(start, end);
}
