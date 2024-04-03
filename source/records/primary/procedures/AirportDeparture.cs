using Arinc424.Attributes;
using Arinc424.Converters;

namespace Arinc424.Procedures;

/// <summary>
/// <c>Airport SID</c> primary record.
/// </summary>
/// <remarks>See section 4.1.9.1.</remarks>

[Record('P', 'D', subsectionIndex: 13)]
public class AirportDeparture : AirportProcedure
{
    /// <inheritdoc cref="DepartureType"/>
    [Character(20), Transform<DepartureTypeConverter>]
    public Terms.DepartureType Type { get; set; }

    /// <inheritdoc cref="DepartureQualifiers"/>
    [Field(119, 120), Decode<DepartureQualifiersConverter>]
    public Terms.DepartureQualifiers Qualifiers { get; set; }
}
