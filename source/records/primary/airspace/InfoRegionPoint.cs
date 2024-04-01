using Arinc.Spec424.Attributes;

namespace Arinc.Spec424.Records;

public class InfoRegionPoint : BoundaryPoint
{
    /// <include file='Comments.xml' path="doc/member[@name='FIR']/*"/>
    [Field(21, 24)]
    public string? Adjacent { get; init; }

    /// <include file='Comments.xml' path="doc/member[@name='FIR']/*"/>
    [Field(25, 28)]
    public string? UpperAdjacent { get; init; }
}
