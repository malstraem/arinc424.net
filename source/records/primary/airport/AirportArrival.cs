using Arinc.Spec424.Attributes;
using Arinc.Spec424.Converters;
using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Records;

/// <summary>
/// <c>Airport STAR</c> primary record.
/// </summary>
/// <remarks>See section 4.1.9.1.</remarks>
[Record('P', 'E', subsectionIndex: 13)]
public class AirportArrival : Procedure
{
    /// <inheritdoc cref="ArrivalType"/>
    [Character(20), Transform<ArrivalTypeConverter>]
    public ArrivalType Type { get; init; }

    /// <inheritdoc cref="ArrivalQualifiers"/>
    [Field(119, 120), Decode<ArrivalQualifiersConverter>]
    public ArrivalQualifiers Qualifiers { get; init; }
}
