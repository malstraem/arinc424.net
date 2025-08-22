namespace Arinc424.Attributes;

/**<summary>
Specifies indexes of section and subsection code to define related entity type.
</summary>
<remarks>
Note that the indices are exactly the same as those defined in the specification.
</remarks>*/
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal class TypeAttribute(int index, int subIndex) : SupplementAttribute
{
    /// <summary>Index of the section character.</summary>
    internal int index = index - 1;

    /// <summary>Index of the subsection character.</summary>
    internal int subIndex = subIndex - 1;

    internal Section GetSection(ReadOnlySpan<char> source) => new(source[index], source[subIndex]);

    internal void Deconstruct(out int index, out int subIndex)
    {
        index = this.index;
        subIndex = this.subIndex;
    }
}
