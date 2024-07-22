namespace Arinc424.Attributes;

/// <summary>
/// Specifies the section and subsection characters/indices to define the entity type of the string.
/// </summary>
/// <remarks>See section 5.4 and 5.5.</remarks>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
internal class SectionAttribute(char section, char subsection = (char)32, int sectionIndex = 5, int subsectionIndex = 6)
    : TypeAttribute(sectionIndex, subsectionIndex)
{
    internal readonly Section Section = new(section, subsection);

    internal bool IsMatch(string @string) => @string[SectionIndex] == Section.Char && @string[SubsectionIndex] == Section.Subchar;
}
