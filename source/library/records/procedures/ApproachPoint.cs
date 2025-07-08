namespace Arinc424.Procedures;

/**<summary>
Fields of <c>Airport</c> and <c>Heliport Approach</c>.
</summary>
<remarks>Used by <see cref="ApproachSequence"/> like subsequence.</remarks>*/
public class ApproachPoint : ProcedurePoint
{
    /**<summary>
    <c>Vertical Angle (VERT ANGLE)</c> field.
    </summary>
    <value>Degrees.</value>
    <remarks>See section 5.70.</remarks>*/
    [Field(103, 106), Float(100)]
    public float VerticalAngle { get; set; }

    /// <inheritdoc cref="Terms.ApproachQualifiers"/>
    [Field(119, 120)]
    public Terms.ApproachQualifiers Qualifiers { get; set; }
}
