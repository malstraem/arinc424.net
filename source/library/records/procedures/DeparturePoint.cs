namespace Arinc424.Procedures;

/**<summary>
Fields of <c>Airport</c> and <c>Heliport SID</c>.
</summary>
<remarks>Used by <see cref="DepartureSequence"/> like subsequence.</remarks>*/
public class DeparturePoint : ProcedurePoint
{
    /// <inheritdoc cref="Terms.DepartureQualifiers"/>
    [Field(119, 120)]
    public Terms.DepartureQualifiers Qualifiers { get; set; }
}
