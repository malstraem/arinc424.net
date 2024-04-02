namespace Arinc424.Converters;

internal abstract class IntConverter : IStringConverter<IntConverter, int>
{
    public static int Convert(string @string) => int.Parse(@string);
}
