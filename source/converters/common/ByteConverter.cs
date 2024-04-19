namespace Arinc424.Converters;

internal abstract class ByteConverter : IStringConverter<ByteConverter, byte>
{
    public static byte Convert(ReadOnlySpan<char> @string) => byte.Parse(@string, System.Globalization.NumberStyles.HexNumber);
}
