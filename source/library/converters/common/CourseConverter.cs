namespace Arinc424.Converters;

using static System.Globalization.NumberStyles;

internal abstract class CourseConverter : IStringConverter<Course>
{
    public static Result<Course> Convert(ReadOnlySpan<char> @string) => @string[^1] is 'T'
        ? float.TryParse(@string[..^1], None, null, out float course)
            ? new Course(course, CourseType.True)
            : @string

        : float.TryParse(@string, None, null, out course)
            ? new Course(course / 10, CourseType.Magnetic)
            : @string;
}
