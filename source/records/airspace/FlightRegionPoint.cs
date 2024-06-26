namespace Arinc424.Airspace;

public class RegionPoint : BoundaryPoint
{
    /// <include file='Comments.xml' path="doc/member[@name='FIR']/*"/>
    [Field(21, 24)]
    public string? Adjacent { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='FIR']/*"/>
    [Field(25, 28)]
    public string? UpperAdjacent { get; set; }
}
