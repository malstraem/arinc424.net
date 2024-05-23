namespace Arinc424.Procedures;

public abstract class Approach : Procedure<ApproachPoint>
{
    /// <inheritdoc cref="Terms.ApproachType"/>
    [Character(20)]
    public Terms.ApproachType Type { get; set; }
}
