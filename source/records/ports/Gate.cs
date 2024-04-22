using System.Diagnostics;

using Arinc424.Attributes;

namespace Arinc424.Ports;

#pragma warning disable CS8618

/// <summary>
/// <c>Airport Gate</c> primary record.
/// </summary>
/// <remarks>See section 4.1.8.1.</remarks>
[Section('P', 'B', subsectionIndex: 13), Continuous]
[DebuggerDisplay($"{{{nameof(Identifier)}}}, {nameof(Airport)} - {{{nameof(Airport)}}}")]
public class Gate : Geo, IIdentity
{
    [Foreign(7, 12)]
    public Airport Airport { get; set; }

    [Field(14, 18)]
    public string Identifier { get; set; }

    [Field(99, 123)]
    public string? Name { get; set; }
}
