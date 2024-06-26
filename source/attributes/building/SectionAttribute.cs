namespace Arinc424.Attributes;

/// <summary>
/// Specifies the section and subsection characters/indices to define the entity type of the string.
/// </summary>
/// <remarks>See section 5.4 and 5.5.</remarks>
[AttributeUsage(AttributeTargets.Class)]
internal class SectionAttribute(char section, char subsection = (char)32, int sectionIndex = 5, int subsectionIndex = 6)
    : TypeAttribute(sectionIndex, subsectionIndex)
{
    internal readonly char Section = section;

    internal readonly char Subsection = subsection;

    internal bool IsMatch(string @string) => @string[SectionIndex] == Section && @string[SubsectionIndex] == Subsection;
}
