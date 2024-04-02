namespace Arinc424.Converters;

/// <summary>
/// Converter for <see cref="CourseType"/>.
/// </summary>
internal abstract class CourseTypeConverter : ICharConverter<CourseTypeConverter, CourseType>
{
    public static CourseType Convert(char @char) => char.IsWhiteSpace(@char) ? CourseType.Mixed : @char switch
    {
        'M' => CourseType.Magnetic,
        'T' => CourseType.True,
        _ => CourseType.Unknown
    };
}
