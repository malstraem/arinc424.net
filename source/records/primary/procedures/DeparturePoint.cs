using Arinc424.Attributes;
using Arinc424.Converters;

namespace Arinc424.Procedures;

public class DeparturePoint : ProcedurePoint
{
    /// <inheritdoc cref="Terms.DepartureQualifiers"/>
    [Field(119, 120), Decode<DepartureQualifiersConverter>]
    public Terms.DepartureQualifiers Qualifiers { get; set; }
}
