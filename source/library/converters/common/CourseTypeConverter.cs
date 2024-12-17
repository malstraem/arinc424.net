namespace Arinc424.Converters;

internal abstract class CourseTypeConverter : ICharConverter<CourseType>
{
    public static bool TryConvert(char @char, out CourseType value)
    {
        switch (@char)
        {
            case 'T': value = CourseType.True; return true;
            case 'M': value = CourseType.Magnetic; return true;
            case (char)32: value = CourseType.Magnetic | CourseType.True; return true;
            default: value = CourseType.Unknown; return false;
        }
    }
}
