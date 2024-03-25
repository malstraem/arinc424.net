namespace Arinc.Spec424.Terms.Converters;

internal class RunwayGradientConverter : IStringConverter
{
    public static object Convert(string @string) => float.Parse(@string) / 1000;
}
