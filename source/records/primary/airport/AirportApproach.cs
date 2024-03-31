using Arinc.Spec424.Attributes;
using Arinc.Spec424.Converters;
using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Records;

/// <summary>
/// <c>Airport Approach</c> primary record.
/// </summary>
/// <remarks>See section 4.1.9.1.</remarks>
[Record('P', 'F', subsectionIndex: 13)]
public class AirportApproach : Procedure
{
    /// <inheritdoc cref="ApproachType"/>
    [Character(20), Transform<ApproachTypeConverter>]
    public ApproachType Type { get; init; }

    /// <inheritdoc cref="ApproachQualifiers"/>
    [Field(119, 120), Decode<ApproachQualifiersConverter>]
    public ApproachQualifiers Qualifiers { get; set; }
}
