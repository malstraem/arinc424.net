using Arinc424.Procedures.Terms;

namespace Arinc424.Procedures;

public class DeparturePoint : ProcedurePoint
{
    /// <inheritdoc cref="DepartureQualifiers"/>
    [Field(119, 120)]
    public DepartureQualifiers Qualifiers { get; set; }
}
