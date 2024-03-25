namespace Arinc.Spec424.Terms.Converters;

internal class EllipsoidalHeightConverter : IStringConverter
{
    public static object Convert(string @string) => float.Parse(@string) / 10;
}
