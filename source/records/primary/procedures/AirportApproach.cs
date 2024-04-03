using Arinc424.Attributes;
using Arinc424.Converters;

namespace Arinc424.Procedures;

/// <summary>
/// <c>Airport Approach</c> primary record.
/// </summary>
/// <remarks>See section 4.1.9.1.</remarks>
[Record('P', 'F', subsectionIndex: 13)]
public class AirportApproach : AirportProcedure
{
    /// <inheritdoc cref="ApproachType"/>
    [Character(20), Transform<ApproachTypeConverter>]
    public Terms.ApproachType Type { get; set; }

    /// <inheritdoc cref="ApproachQualifiers"/>
    [Field(119, 120), Decode<ApproachQualifiersConverter>]
    public Terms.ApproachQualifiers Qualifiers { get; set; }
}
