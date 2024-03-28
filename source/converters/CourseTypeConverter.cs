using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Converters;

internal class CourseTypeConverter : ICharConverter
{
    public static object Convert(char @char) => @char switch
    {
        'M' => CourseType.Magnetic,
        'T' => CourseType.True,
        _ when char.IsWhiteSpace(@char) => CourseType.Mixed,
        _ => CourseType.Unknown
    };
}
