using Arinc424.Tables.Terms;

namespace Arinc424.Tables;

#pragma warning disable CS8618

public class CruiseTableRow : Record424
{
    /// <summary>
    /// <c>Course FROM</c> field.
    /// </summary>
    /// <value>Degrees and tenths of degree.</value>
    /// <remarks>See section 5.135.</remarks>
    [Field(29, 32), Float(10)]
    public float From { get; set; }

    /// <summary>
    /// <c>Course TO</c> field.
    /// </summary>
    /// <value>Degrees and tenths of degree.</value>
    /// <remarks>See section 5.135.</remarks>
    [Field(33, 36), Float(10)]
    public float To { get; set; }

    /// <summary>
    /// <c>Magnetic/True Indicator (M/T IND)</c> character.
    /// </summary>
    /// <remarks>See section 5.165.</remarks>
    [Character(38)]
    public CourseType CourseType { get; set; }

    [Field(40, 54), Count(4)]
    public LevelRange[] LevelRanges { get; set; }
}
