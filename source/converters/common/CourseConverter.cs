namespace Arinc424.Converters;

internal abstract class CourseConverter : IStringConverter<CourseConverter, (float, CourseType)>
{
    public static (float, CourseType) Convert(string @string) => @string.Last() is 'T'
        ? (float.Parse(@string[..(@string.Length - 1)]), CourseType.True)
        : (float.Parse(@string) / 10, CourseType.Magnetic);
}
