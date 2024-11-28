namespace Arinc424.Ground;

/// <summary>
/// <c>Airport Gate</c> primary record.
/// </summary>
/// <remarks>See section 4.1.8.1.</remarks>
[Section('P', 'B', subsectionIndex: 13), Icao(11, 12), Continuous]

[DebuggerDisplay($"{{{nameof(Identifier)},nq}}, {nameof(Airport)} - {{{nameof(Airport)}}}")]
public class Gate : Geo, IIdentity, INamed
{
    [Identifier(7, 10)]
    public Airport Airport { get; set; }

    [Field(11, 12)]
    public string IcaoCode { get; set; }

    /// <summary>
    /// <c>Gate Identifier (GATE IDENT)</c> field.
    /// </summary>
    /// <remarks>See section 5.56.</remarks>
    [Field(14, 18)]
    public string Identifier { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Name']/*"/>
    [Field(99, 123)]
    public string? Name { get; set; }
}
