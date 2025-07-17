namespace Arinc424.Attributes;

/**<summary>
Specifies indexes of section and subsection code to define related entity type.
</summary>*/
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal class TypeAttribute(int index, int subIndex) : SupplementAttribute
{
    /// <summary>Index of the section character.</summary>
    protected int index = index - 1;

    /// <summary>Index of the subsection character.</summary>
    protected int subIndex = subIndex - 1;

    internal void Deconstruct(out int index, out int subIndex)
    {
        index = this.index;
        subIndex = this.subIndex;
    }
}
