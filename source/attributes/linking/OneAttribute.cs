namespace Arinc424.Attributes;

/// <summary>
/// Specifies that the property is one-to-one and relationship must be established after parsing.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
internal class OneAttribute : Attribute;
