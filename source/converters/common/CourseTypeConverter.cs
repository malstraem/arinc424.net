namespace Arinc424.Converters;

internal abstract class CourseTypeConverter : ICharConverter<CourseTypeConverter, CourseType>
{
    public static CourseType Convert(char @char) => char.IsWhiteSpace(@char) ? CourseType.Mixed : @char switch
    {
        'M' => CourseType.Magnetic,
        'T' => CourseType.True,
        _ => CourseType.Unknown
    };
}
