namespace Arinc424.Attributes;

/**<summary>
Specifies the section and subsection characters/indices to define the entity type of the string.
</summary>
<inheritdoc/>*/
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
internal sealed class SectionAttribute(char @char, char sub = (char)32, int ind = 5, int subInd = 6)
    : TypeAttribute(ind, subInd)
{
    internal Section Value { get; } = new(@char, sub);

    internal bool IsMatch(string @string) => @string[ind] == Value.Char && @string[subInd] == Value.Sub;
}
