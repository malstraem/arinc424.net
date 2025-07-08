namespace Arinc424.Ground;

using Processing;

/**<summary>
<c>Heliport</c> primary record.
</summary>
<remarks>See section 4.2.1.1.</remarks>*/
[Section('H', 'A', subIndex: 13), Pipeline<HelipadWrapBeforeV21>(End = Supplement.V21)]

[Obsolete("todo")]
public class Heliport : Port
{
    /// <summary>Associated Helipads.</summary>
    [Many]
    public Helipad[]? Helipads { get; set; }
}
