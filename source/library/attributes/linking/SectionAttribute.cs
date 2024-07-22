namespace Arinc424.Attributes;

/// <summary>
/// Specifies indexes of section and subsection code to define related entity type.
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal class TypeAttribute(int sectionIndex, int subsectionIndex, Supplement supplement = Supplement.V18) : SupplementAttribute(supplement)
{
    /// <summary>
    /// Index of the section character.
    /// </summary>
    internal int SectionIndex = sectionIndex - 1;

    /// <summary>
    /// Index of the subsection character.
    /// </summary>
    internal int SubsectionIndex = subsectionIndex - 1;
}
