namespace Arinc424.Converters;

internal abstract class ThousandsConverter : IStringConverter<ThousandsConverter, float>
{
    public static float Convert(string @string) => float.Parse(@string) / 1000;
}
