namespace Arinc424.Attributes;

[AttributeUsage(AttributeTargets.Property)]
internal class TypeAttribute(int sectionIndex, int subsectionIndex) : Attribute
{
    /// <summary>
    /// Index of the section character.
    /// </summary>
    internal int SectionIndex { get; } = sectionIndex - 1;

    /// <summary>
    /// Index of the subsection character.
    /// </summary>
    internal int SubsectionIndex { get; } = subsectionIndex - 1;
}
