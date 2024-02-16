using System.Diagnostics;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Records.Subsequences;

namespace Arinc.Spec424.Records;

#pragma warning disable CS8618

/// <summary>
/// <c>Enroute Airways</c> primary record.
/// </summary>
/// <remarks>See paragraph 4.1.6.1.</remarks>
[Record('E', 'R'), Continuation(39), Sequenced(26, 29)]
[DebuggerDisplay($"{{{nameof(Identifier)}}}")]
public class Airway : Record424<AirwayPoint>, IIdentity
{
    /// <summary>
    /// <c>Route Identifier (ROUTE IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.8</remarks>
    [Field(14, 18)]
    public string Identifier { get; init; }
}
