using System.Globalization;

namespace Arinc424.Converters;

internal abstract class ByteConverter : IStringConverter<ByteConverter, byte>
{
    public static Result<byte> Convert(ReadOnlySpan<char> @string) => !byte.TryParse(@string, NumberStyles.HexNumber, null, out byte value)
            ? new Result<byte>($"Byte '{@string}' can't be parsed.")
            : value;
}
