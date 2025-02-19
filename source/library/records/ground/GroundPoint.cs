using Arinc424.Ground.Terms;

namespace Arinc424.Ground;

/**<summary>
<c>GBAS Path Point</c> primary record.
</summary>
<remarks>See section 4.1.35.1.</remarks>*/
[Section('P', 'Q', subsectionIndex: 13)]
public class GroundPoint : PathPoint
{
    /// <inheritdoc cref="GroundOperationType"/>
    [Field(25, 26)]
    public GroundOperationType OperationType { get; set; }
}
