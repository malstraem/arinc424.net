using Arinc424.Procedures.Terms;

namespace Arinc424.Procedures;

/**<summary>
Fields of <c>Airport</c> and <c>Heliport SID</c>.
</summary>
<remarks>Used by <see cref="DepartureSequence"/> like subsequence.</remarks>*/
public class DeparturePoint : ProcedurePoint
{
    /// <inheritdoc cref="DepartureQualifiers"/>
    [Field(119, 120)]
    public DepartureQualifiers Qualifiers { get; set; }
}
