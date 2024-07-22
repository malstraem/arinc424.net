using Arinc424.Processing;

namespace Arinc424.Ports;

/// <summary>
/// <c>Heliport</c> primary record.
/// </summary>
/// <remarks>See section 4.2.1.1.</remarks>
[Section('H', 'A', subsectionIndex: 13)]
[Process<Heliport, Heliport, HelipadConcatenater>(end: Supplement.V21)]
public class Heliport : Port
{
    /// <summary>
    /// Associated Helipads.
    /// </summary>
    [Many]
    public List<Helipad>? Helipads { get; set; }
}
