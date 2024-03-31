using Arinc.Spec424.Attributes;
using Arinc.Spec424.Converters;
using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Records;

/// <summary>
/// <c>Airport SID</c> primary record.
/// </summary>
/// <remarks>See section 4.1.9.1.</remarks>

[Record('P', 'D', subsectionIndex: 13)]
public class AirportDeparture : Procedure
{
    /// <inheritdoc cref="DepartureType"/>
    [Character(20), Transform<DepartureTypeConverter>]
    public DepartureType Type { get; init; }

    /// <inheritdoc cref="DepartureQualifiers"/>
    [Field(119, 120), Decode<DepartureQualifiersConverter>]
    public DepartureQualifiers Qualifiers { get; init; }
}
