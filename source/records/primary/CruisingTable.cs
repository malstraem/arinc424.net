using Arinc.Spec424.Attributes;

namespace Arinc.Spec424.Records;

/// <summary>
/// <c>Cruising Table</c> record.
/// </summary>
/// <remarks>See paragraph 4.1.16.1.</remarks>
[Record('T', 'C')]
public record CruisingTable : Record424
{
    /// <summary>
    /// <c>Cruise Table Identifier (CRSE TBL IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.134.</remarks>
    [Field(7, 8)]
    public required string CruisingTableIdentifier { get; init; }

    /// <summary>
    /// <c>Course FROM</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.135.</remarks>
    [Field(29, 32)]
    public required string CourseFrom { get; init; }

    /// <summary>
    /// <c>Course TO</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.135.</remarks>
    [Field(33, 36)]
    public required string CourseTo { get; init; }

    /// <summary>
    /// <c>Magnetic/True Indicator (M/T IND)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.165.</remarks>
    [Character(38)]
    public required char CourseIndicator { get; init; }

    /// <summary>
    /// <c>Cruise Level From</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.136.</remarks>
    [Field(40, 44)]
    public required string CruiseLevelFrom1 { get; init; }

    /// <summary>
    /// <c>Vertical Separation</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.137.</remarks>
    [Field(45, 49)]
    public required string VerticalSeparation1 { get; init; }

    /// <summary>
    /// <c>Cruise Level To</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.136.</remarks>
    [Field(50, 54)]
    public required string CruiseLevelTo1 { get; init; }

    /// <summary>
    /// <c>Cruise Level From</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.136.</remarks>
    [Field(55, 59)]
    public required string CruiseLevelFrom2 { get; init; }

    /// <summary>
    /// <c>Vertical Separation</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.137.</remarks>
    [Field(60, 64)]
    public required string VerticalSeparation2 { get; init; }

    /// <summary>
    /// <c>Cruise Level To</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.136.</remarks>
    [Field(65, 69)]
    public required string CruiseLevelTo2 { get; init; }

    /// <summary>
    /// <c>Cruise Level From</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.136.</remarks>
    [Field(70, 74)]
    public required string CruiseLevelFrom3 { get; init; }

    /// <summary>
    /// <c>Vertical Separation</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.137.</remarks>
    [Field(75, 79)]
    public required string VerticalSeparation3 { get; init; }

    /// <summary>
    /// <c>Cruise Level To</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.136.</remarks>
    [Field(80, 84)]
    public required string CruiseLevelTo3 { get; init; }

    /// <summary>
    /// <c>Cruise Level From</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.136.</remarks>
    [Field(85, 89)]
    public required string CruiseLevelFrom4 { get; init; }

    /// <summary>
    /// <c>Vertical Separation</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.137.</remarks>
    [Field(90, 94)]
    public required string VerticalSeparation4 { get; init; }

    /// <summary>
    /// <c>Cruise Level To</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.136.</remarks>
    [Field(95, 99)]
    public required string CruiseLevelTo4 { get; init; }
}
