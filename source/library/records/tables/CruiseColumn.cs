namespace Arinc424.Tables;

/**<summary>
Fields of <c>Cruising Table</c>.
</summary>
<remarks>Used by <see cref="CruiseTable"/> like subsequence.</remarks>*/
public class CruiseColumn : Record424, ISequenced
{
    [Field(9, 9), Integer]
    public int SeqNumber { get; set; }

    /**<summary>
    <c>Course FROM</c> field.
    </summary>
    <value>Degrees.</value>
    <remarks>See section 5.135.</remarks>*/
    [Field(29, 32), Float(10)]
    public float From { get; set; }

    /**<summary>
    <c>Course TO</c> field.
    </summary>
    <value>Degrees.</value>
    <remarks>See section 5.135.</remarks>*/
    [Field(33, 36), Float(10)]
    public float To { get; set; }

    /// <summary><c>Magnetic/True Indicator (M/T IND)</c> character.</summary>
    /// <remarks>See section 5.165.</remarks>
    [Character(38)]
    public CourseType CourseType { get; set; }

    [Field(40, 54), Count(4)]
    public Terms.Level[] Levels { get; set; }
}
