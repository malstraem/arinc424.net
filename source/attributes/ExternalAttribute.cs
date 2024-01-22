namespace Arinc.Spec424.Attributes;

/// <summary>
/// Specifies that the entity is external linked and defines range of link within a string.
/// </summary>
/// <param name="propertyNames">One or more property names that are combined into a foreign key.</param>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
internal class ExternalAttribute(params string[] propertyNames) : Attribute
{
    /// <summary>
    /// Range of the external link.
    /// </summary>
    internal string[] PropertyNames { get; } = propertyNames;
}
