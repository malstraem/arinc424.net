namespace Arinc424.Attributes;

/**<summary>
Specifies indexes of section and subsection code to define related entity type.
</summary>
<remarks>
Note that the indices are exactly the same as those defined in the specification.
</remarks>*/
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal class TypeAttribute(int ind, int subInd) : SupplementAttribute
{
    /// <summary>Index of the section character.</summary>
    internal int ind = ind - 1;

    /// <summary>Index of the subsection character.</summary>
    internal int subInd = subInd - 1;

    internal Section GetSection(ReadOnlySpan<char> source) => new(source[ind], source[subInd]);

    internal void Deconstruct(out int ind, out int subInd)
    {
        ind = this.ind;
        subInd = this.subInd;
    }
}
