using Arinc424.Procedures.Terms;

namespace Arinc424.Procedures;

public class ArrivalPoint : ProcedurePoint
{
    /// <summary>
    /// <c>Vertical Angle (VERT ANGLE)</c> field.
    /// </summary>
    /// <remarks>See section 5.70.</remarks>
    [Field(103, 106), Float(100)]
    public float VerticalAngel { get; set; }

    /// <inheritdoc cref="ArrivalQualifiers"/>
    [Field(119, 120)]
    public ArrivalQualifiers Qualifiers { get; set; }
}
