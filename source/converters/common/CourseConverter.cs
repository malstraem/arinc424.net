namespace Arinc424.Converters;

internal abstract class CourseConverter : IStringConverter<CourseConverter, Course>
{
    public static Course Convert(ReadOnlySpan<char> @string) => @string[^1] is 'T'
        ? new(float.Parse(@string[..(@string.Length - 1)]), CourseType.True)
        : new(float.Parse(@string) / 10, CourseType.Magnetic);
}
