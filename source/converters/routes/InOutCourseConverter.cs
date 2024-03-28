namespace Arinc.Spec424.Converters;

internal class InOutCourseConverter : IStringConverter
{
    public static object Convert(string @string) => @string.Last() is 'T'
        ? float.Parse(@string[..(@string.Length - 1)])
        : (object)(float.Parse(@string) / 10);
}
