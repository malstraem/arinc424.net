namespace Arinc424.Converters;

internal abstract class CourseConverter : IStringConverter<CourseConverter, (float, CourseType)>
{
    public static (float, CourseType) Convert(ReadOnlySpan<char> @string) => @string[^1] is 'T'
        ? (float.Parse(@string[..(@string.Length - 1)]), CourseType.True)
        : (float.Parse(@string) / 10, CourseType.Magnetic);
}
