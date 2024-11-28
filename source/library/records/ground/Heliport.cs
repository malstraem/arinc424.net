using Arinc424.Processing;

namespace Arinc424.Ground;

/// <summary>
/// <c>Heliport</c> primary record.
/// </summary>
/// <remarks>See section 4.2.1.1.</remarks>
[Section('H', 'A', subsectionIndex: 13)]

[Pipeline<HelipadWrapBeforeV21>(end: Supplement.V21)]

[Obsolete("todo")]
public class Heliport : Port
{
    /// <summary>
    /// Associated Helipads.
    /// </summary>
    [Many]
    public List<Helipad>? Helipads { get; set; }
}
