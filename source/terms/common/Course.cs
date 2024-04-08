namespace Arinc424;

public struct Course(float value, CourseType type)
{
    public float Value { get; set; } = value;

    public CourseType Type { get; set; } = type;
}
