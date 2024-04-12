using System.Diagnostics;

using Arinc424.Attributes;

namespace Arinc424.Ports;

#pragma warning disable CS8618

/// <summary>
/// <c>Airport Gate</c> primary record.
/// </summary>
/// <remarks>See section 4.1.8.1.</remarks>
[Record('P', 'B', subsectionIndex: 13), Continuous]
[DebuggerDisplay($"{{{nameof(Identifier)}}}, Name - {{{nameof(Name)}}}")]
public class Gate : Geo, IIcao, IIdentity
{
    [Foreign(7, 12)]
    public Airport Airport { get; set; }

    public string IcaoCode => Airport.IcaoCode;

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
