namespace Arinc424.Converters;

internal abstract class CourseConverter : IStringConverter<CourseConverter, Course>
{
    public static Result<Course> Convert(ReadOnlySpan<char> @string) => @string[^1] is 'T'
        ? float.TryParse(@string[..^1], out float course)
            ? new Course(course, CourseType.True)
            : new Result<Course>($"True course '{@string}' can't be parsed.")
        : float.TryParse(@string, out course)
            ? new Course(course / 10, CourseType.Magnetic)
            : new Result<Course>($"Magnetic course '{@string}' can't be parsed.");
}
