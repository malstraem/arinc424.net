namespace Arinc424.Converters;

internal abstract class CourseConverter : IStringConverter<CourseConverter, Course>
{
    public static Result<Course> Convert(ReadOnlySpan<char> @string)
    {
        if (@string[^1] is 'T')
        {
            return !float.TryParse(@string[..^1], out float course)
                ? new Result<Course>($"True course '{@string}' can't be parsed.")
                : new Course(course, CourseType.True);
        }
        else
        {
            return !float.TryParse(@string, out float course)
                ? new Result<Course>($"Magnetic course '{@string}' can't be parsed.")
                : new Course(course / 10, CourseType.Magnetic);
        }
    }
}
