namespace Arinc424.Attributes;

/// <summary>
/// Specifies that the property is a part of primary key to establish a relationship.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
internal class PrimaryAttribute : Attribute;
