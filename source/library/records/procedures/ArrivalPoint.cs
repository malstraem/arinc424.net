using Arinc424.Procedures.Terms;

namespace Arinc424.Procedures;

/**<summary>
Fields of <c>Airport</c> and <c>Heliport STAR</c>.
</summary>
<remarks>Used by <see cref="ArrivalSequence"/> like subsequence.</remarks>*/
public class ArrivalPoint : ProcedurePoint
{
    /// <inheritdoc cref="ApproachPoint.VerticalAngle"/>
    [Field(103, 106), Float(100)]
    public float VerticalAngle { get; set; }

    /// <inheritdoc cref="ArrivalQualifiers"/>
    [Field(119, 120)]
    public ArrivalQualifiers Qualifiers { get; set; }
}
