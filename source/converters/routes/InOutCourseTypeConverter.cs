using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Converters;

internal class InOutCourseTypeConverter : IStringConverter
{
    public static object Convert(string @string) => @string.Last() is not 'T' ? CourseType.Magnetic : CourseType.True;
}
