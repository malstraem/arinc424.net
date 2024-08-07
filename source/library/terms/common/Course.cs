namespace Arinc424;

/// <summary>
/// Various courses and bearings according to the specification.
/// </summary>
[Decode<CourseConverter, Course>]
[DebuggerDisplay($"{{{nameof(Value)}}}, {{{nameof(Type)}}}")]
public struct Course(float value, CourseType type)
{
    public float Value { get; set; } = value;

    public CourseType Type { get; set; } = type;
}
