namespace Arinc.Spec424.Terms.Converters;

internal class CourseTypeConverter : ICharConverter
{
    public static object Convert(char @char) => @char switch
    {
        'M' => CourseType.Magnetic,
        'T' => CourseType.True,
        (char)32 => CourseType.Mixed,
        _ => throw new ConvertException(@char.ToString(), $"Char {@char} is not valid course type")
    };
}
