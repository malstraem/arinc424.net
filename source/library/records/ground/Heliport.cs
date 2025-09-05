namespace Arinc424.Ground;

using Processing;

/**<summary>
<c>Heliport</c> primary record.
</summary>
<remarks>See section 4.2.1.1.</remarks>*/
[Section('H', 'A', subInd: 13), Pipe<PadWrapBeforeV21>(End = Supplement.V21)]

[Obsolete("todo")]
public class Heliport : Port;
