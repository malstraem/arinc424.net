namespace Arinc.Spec424.Attributes;

/// <summary>
/// Specifies that the entity is external linked and defines range of link within a string.
/// </summary>
/// <param name="start"></param>
/// <param name="end"></param>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
internal class ExternalAttribute(int start, int end) : Attribute
{
    /// <summary>
    /// Range of the external link.
    /// </summary>
    internal Range Range { get; } = new Range(start - 1, end);
}
