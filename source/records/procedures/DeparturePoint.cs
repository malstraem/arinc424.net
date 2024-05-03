using Arinc424.Attributes;
using Arinc424.Converters;
using Arinc424.Procedures.Terms;

namespace Arinc424.Procedures;

public class DeparturePoint : ProcedurePoint
{
    /// <inheritdoc cref="DepartureQualifiers"/>
    [Field(119, 120), Decode<DepartureQualifiersConverter>]
    public DepartureQualifiers Qualifiers { get; set; }
}
