namespace Arinc424.Attributes;

/// <summary>
/// Specifies that the property is one-to-many and relationships must be established after parsing.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
internal class ManyAttribute : Attribute;
