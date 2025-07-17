namespace Arinc424.Attributes;

/**<summary>
Specifies the section and subsection characters/indices to define the entity type of the string.
</summary>
<remarks>See section 5.4 and 5.5.</remarks>*/
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
internal class SectionAttribute(char section, char subsection = (char)32, int index = 5, int subIndex = 6)
    : TypeAttribute(index, subIndex)
{
    internal Section Value { get; } = new(section, subsection);

    internal bool IsMatch(string @string) => @string[index] == Value.Char && @string[subIndex] == Value.Subchar;
}
