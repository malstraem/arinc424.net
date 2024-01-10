namespace Arinc.Spec424.Terms.Converters;

internal class NumericConverter : IStringConverter
{
    public static object Convert(string @string) => int.Parse(@string);
}
