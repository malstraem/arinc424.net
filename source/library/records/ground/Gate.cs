namespace Arinc424.Ground;

/**<summary>
<c>Airport Gate</c> primary record.
</summary>
<remarks>See section 4.1.8.1.</remarks>*/
[Section('P', 'B', subsectionIndex: 13), Icao(11, 12), Continuous]

[DebuggerDisplay($"{{{nameof(Identifier)},nq}}, {nameof(Airport)} - {{{nameof(Airport)}}}")]
public class Gate : Fix, INamed
{
    [Identifier(7, 10)]
    public Airport Airport { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Name']/*"/>
    [Field(99, 123)]
    public string? Name { get; set; }
}
