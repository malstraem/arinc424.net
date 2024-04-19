using Arinc424.Attributes;
using Arinc424.Converters;

namespace Arinc424.Procedures;

public abstract class Approach : Procedure<ApproachPoint>
{
    /// <inheritdoc cref="Terms.ApproachType"/>
    [Character(20), Transform<ApproachTypeConverter>]
    public Terms.ApproachType Type { get; set; }
}
