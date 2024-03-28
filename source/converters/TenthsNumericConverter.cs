namespace Arinc.Spec424.Converters;

internal class TenthsNumericConverter : IStringConverter
{
    public static object Convert(string @string) => float.Parse(@string) / 10;
}
