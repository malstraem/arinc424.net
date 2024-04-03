using Arinc424.Attributes;
using Arinc424.Converters;

namespace Arinc424.Procedures;

/// <summary>
/// <c>Airport STAR</c> primary record.
/// </summary>
/// <remarks>See section 4.1.9.1.</remarks>
[Record('P', 'E', subsectionIndex: 13)]
public class AirportArrival : AirportProcedure
{
    /// <inheritdoc cref="ArrivalType"/>
    [Character(20), Transform<ArrivalTypeConverter>]
    public Terms.ArrivalType Type { get; set; }

    /// <inheritdoc cref="ArrivalQualifiers"/>
    [Field(119, 120), Decode<ArrivalQualifiersConverter>]
    public Terms.ArrivalQualifiers Qualifiers { get; set; }
}
