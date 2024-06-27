namespace Arinc424.Airspace;

/// <summary>
/// Fields of <c>FIR/UIR</c>.
/// </summary>
/// <remarks>Used by <see cref="RegionVolume"/> like subsequence.</remarks>
public class RegionPoint : BoundaryPoint
{
    /// <include file='Comments.xml' path="doc/member[@name='FIR']/*"/>
    [Field(21, 24), Obsolete("todo: link")]
    public string? Adjacent { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='FIR']/*"/>
    [Field(25, 28), Obsolete("todo: link")]
    public string? UpperAdjacent { get; set; }
}
