namespace Arinc.Spec424.Attributes;

/// <summary>
/// Specifies that the property is one-to-many and relationships should be established after parsing.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
internal class ManyAttribute : Attribute;
