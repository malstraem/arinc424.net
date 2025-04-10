namespace Arinc424.Attributes;

/**<summary>
Specifies indexes of section and subsection code to define related entity type.
</summary>*/
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal class TypeAttribute(int sectionIndex, int subsectionIndex) : SupplementAttribute
{
    /// <summary>Index of the section character.</summary>
    protected int sectionIndex = sectionIndex - 1;

    /// <summary>Index of the subsection character.</summary>
    protected int subsectionIndex = subsectionIndex - 1;

    internal void Deconstruct(out int index, out int subIndex)
    {
        index = sectionIndex;
        subIndex = subsectionIndex;
    }
}
