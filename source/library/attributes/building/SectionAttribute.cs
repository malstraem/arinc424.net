namespace Arinc424.Attributes;

/**<summary>
Specifies the section and subsection characters/indices to define the entity type of the string.
</summary>
<inheritdoc/>*/
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
internal sealed class SectionAttribute(char section, char subsection = (char)32, int index = 5, int subIndex = 6)
    : TypeAttribute(index, subIndex)
{
    internal Section Value { get; } = new(section, subsection);

    internal bool IsMatch(string @string) => @string[index] == Value.Char && @string[subIndex] == Value.Sub;
}
