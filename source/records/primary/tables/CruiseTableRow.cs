using Arinc424.Attributes;

namespace Arinc424.Tables;

public class CruiseTableRow : Record424
{
    /// <summary>
    /// <c>Course FROM</c> field.
    /// </summary>
    /// <remarks>See section 5.135.</remarks>
    [Field(29, 32)]
    public string CourseFrom { get; set; }

    /// <summary>
    /// <c>Course TO</c> field.
    /// </summary>
    /// <remarks>See section 5.135.</remarks>
    [Field(33, 36)]
    public string CourseTo { get; set; }

    /// <summary>
    /// <c>Magnetic/True Indicator (M/T IND)</c> character.
    /// </summary>
    /// <remarks>See section 5.165.</remarks>
    [Character(38)]
    public char CourseIndicator { get; set; }

    /// <summary>
    /// <c>Cruise Level From</c> field.
    /// </summary>
    /// <remarks>See section 5.136.</remarks>
    [Field(40, 44)]
    public string CruiseLevelFrom1 { get; set; }

    /// <summary>
    /// <c>Vertical Separation</c> field.
    /// </summary>
    /// <remarks>See section 5.137.</remarks>
    [Field(45, 49)]
    public string VerticalSeparation1 { get; set; }

    /// <summary>
    /// <c>Cruise Level To</c> field.
    /// </summary>
    /// <remarks>See section 5.136.</remarks>
    [Field(50, 54)]
    public string CruiseLevelTo1 { get; set; }

    /// <summary>
    /// <c>Cruise Level From</c> field.
    /// </summary>
    /// <remarks>See section 5.136.</remarks>
    [Field(55, 59)]
    public string CruiseLevelFrom2 { get; set; }

    /// <summary>
    /// <c>Vertical Separation</c> field.
    /// </summary>
    /// <remarks>See section 5.137.</remarks>
    [Field(60, 64)]
    public string VerticalSeparation2 { get; set; }

    /// <summary>
    /// <c>Cruise Level To</c> field.
    /// </summary>
    /// <remarks>See section 5.136.</remarks>
    [Field(65, 69)]
    public string CruiseLevelTo2 { get; set; }

    /// <summary>
    /// <c>Cruise Level From</c> field.
    /// </summary>
    /// <remarks>See section 5.136.</remarks>
    [Field(70, 74)]
    public string CruiseLevelFrom3 { get; set; }

    /// <summary>
    /// <c>Vertical Separation</c> field.
    /// </summary>
    /// <remarks>See section 5.137.</remarks>
    [Field(75, 79)]
    public string VerticalSeparation3 { get; set; }

    /// <summary>
    /// <c>Cruise Level To</c> field.
    /// </summary>
    /// <remarks>See section 5.136.</remarks>
    [Field(80, 84)]
    public string CruiseLevelTo3 { get; set; }

    /// <summary>
    /// <c>Cruise Level From</c> field.
    /// </summary>
    /// <remarks>See section 5.136.</remarks>
    [Field(85, 89)]
    public string CruiseLevelFrom4 { get; set; }

    /// <summary>
    /// <c>Vertical Separation</c> field.
    /// </summary>
    /// <remarks>See section 5.137.</remarks>
    [Field(90, 94)]
    public string VerticalSeparation4 { get; set; }

    /// <summary>
    /// <c>Cruise Level To</c> field.
    /// </summary>
    /// <remarks>See section 5.136.</remarks>
    [Field(95, 99)]
    public string CruiseLevelTo4 { get; set; }
}
