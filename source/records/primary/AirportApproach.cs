using Arinc.Spec424.Attributes;

namespace Arinc.Spec424.Records;

/// <summary>
/// <c>Airport Approach</c> primary record.
/// </summary>
/// <remarks>See paragraph 4.1.9.1.</remarks>
[Record('P', 'F', subsectionIndex: 13)]
public record AirportApproach : Procedure { }
