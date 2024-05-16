namespace Arinc424.Procedures;

public abstract class Departure : Procedure<DeparturePoint>
{
    /// <inheritdoc cref="Terms.DepartureType"/>
    [Character(20), Transform<DepartureTypeConverter>]
    public Terms.DepartureType Type { get; set; }
}
