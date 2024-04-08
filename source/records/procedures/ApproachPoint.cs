using Arinc424.Attributes;
using Arinc424.Converters;

namespace Arinc424.Procedures;

public class ApproachPoint : ProcedurePoint
{
    /// <summary>
    /// <c>Vertical Angle (VERT ANGLE)</c> field.
    /// </summary>
    /// <remarks>See section 5.70.</remarks>
    [Field(103, 106), Decode<HundredthsConverter>]
    public float VerticalAngel { get; set; }

    /// <inheritdoc cref="Terms.ApproachQualifiers"/>
    [Field(119, 120), Decode<ApproachQualifiersConverter>]
    public Terms.ApproachQualifiers Qualifiers { get; set; }
}
