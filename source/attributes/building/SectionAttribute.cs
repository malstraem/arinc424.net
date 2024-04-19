namespace Arinc424.Attributes;

/// <summary>
/// Specifies the section and subsection characters/indices to define the entity type of the string.
/// </summary>
/// <remarks>See section 5.4 and 5.5.</remarks>
[AttributeUsage(AttributeTargets.Class)]
internal class SectionAttribute(char sectionChar, char subsectionChar = (char)32, int sectionIndex = 5, int subsectionIndex = 6) : TypeAttribute(sectionIndex, subsectionIndex)
{
    /// <summary>
    /// Section character.
    /// </summary>
    internal char SectionChar = sectionChar;

    /// <summary>
    /// Subsection character.
    /// </summary>
    internal char SubsectionChar = subsectionChar;

    internal bool IsMatch(string @string) => @string[SectionIndex] == SectionChar
                                          && @string[SubsectionIndex] == SubsectionChar;
}
