using Arinc424.Procedures.Terms;

namespace Arinc424.Procedures;

/// <summary>
/// Fields of <c>Approach</c>.
/// </summary>
/// <remarks>Used by <see cref="ApproachSequence"/> like subsequence.</remarks>
public class ApproachPoint : ProcedurePoint
{
    /// <summary>
    /// <c>Vertical Angle (VERT ANGLE)</c> field.
    /// </summary>
    /// <remarks>See section 5.70.</remarks>
    [Field(103, 106), Float(100)]
    public float VerticalAngle { get; set; }

    /// <inheritdoc cref="ApproachQualifiers"/>
    [Field(119, 120)]
    public ApproachQualifiers Qualifiers { get; set; }
}
