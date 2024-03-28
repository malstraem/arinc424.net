using System.Diagnostics;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Records.Sub;

namespace Arinc.Spec424.Records;

#pragma warning disable CS8618

/// <summary>
/// <c>Enroute Airways</c> primary record.
/// </summary>
/// <remarks>See section 4.1.6.1.</remarks>
[Record('E', 'R'), Continuous(39), Sequenced(26, 29)]
[DebuggerDisplay($"{{{nameof(Identifier)}}}")]
public class Airway : Record424<AirwayPoint>, IIdentity
{
    /// <include file='Comments.xml' path="doc/member[@name='RouteIdentifier']/*"/>
    [Field(14, 18)]
    public string Identifier { get; init; }
}
