namespace Arinc.Spec424.Converters;

internal abstract class TenthsConverter : IStringConverter<TenthsConverter, float>
{
    public static float Convert(string @string) => float.Parse(@string) / 10;
}
