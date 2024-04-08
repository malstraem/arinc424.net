using Arinc424.Attributes;
using Arinc424.Converters;

namespace Arinc424.Procedures;

public class Arrival : Procedure<ArrivalPoint>
{
    /// <inheritdoc cref="Terms.ArrivalType"/>
    [Character(20), Transform<ArrivalTypeConverter>]
    public Terms.ArrivalType Type { get; set; }
}
