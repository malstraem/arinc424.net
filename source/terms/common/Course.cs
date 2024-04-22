using System.Diagnostics;

namespace Arinc424;

[DebuggerDisplay($"{{{nameof(Value)}}}, {{{nameof(Type)}}}")]
public struct Course(float value, CourseType type)
{
    public float Value { get; set; } = value;

    public CourseType Type { get; set; } = type;
}
