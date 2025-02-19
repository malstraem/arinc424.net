namespace Arinc424;

/**<summary>
Various courses and bearings according to the specification.
</summary>
<remarks>See section 5.26, 5.28, 5.47, 5.58, 5.62 and 5.167.</remarks>*/
[Decode<CourseConverter, Course>]
[DebuggerDisplay($"{{{nameof(Value)}}}, {{{nameof(Type)}}}")]
public struct Course(float value, CourseType type)
{
    /// <summary>Angle.</summary>
    /// <value>Degrees.</value>
    public float Value { get; set; } = value;

    /// <inheritdoc cref="CourseType"/>
    public CourseType Type { get; set; } = type;
}
