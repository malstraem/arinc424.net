namespace Arinc424.Procedures;

public abstract class Arrival : Procedure<ArrivalPoint>
{
    /// <inheritdoc cref="Terms.ArrivalType"/>
    [Character(20), Transform<ArrivalTypeConverter>]
    public Terms.ArrivalType Type { get; set; }
}
