using Arinc.Spec424.Attributes;

using Arinc424.Terms.Subsequences;

namespace Arinc.Spec424.Records;

/// <summary>
/// <c>Enroute Airways</c> primary record.
/// </summary>
/// <remarks>See paragraph 4.1.6.1.</remarks>
[Record('E', 'R'), Continuation(39), Sequenced(26, 29)]
public class Airway : SequencedRecord424<AirwayPoint>
{
    /// <summary>
    /// <c>Route Identifier (ROUTE IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.8</remarks>
    [Field(14, 18)]
    public required string RouteIdentifier { get; init; }
}
