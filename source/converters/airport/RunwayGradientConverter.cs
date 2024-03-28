namespace Arinc.Spec424.Converters;

internal class RunwayGradientConverter : IStringConverter
{
    public static object Convert(string @string) => float.Parse(@string) / 1000;
}
