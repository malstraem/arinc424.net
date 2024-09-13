namespace Arinc424.Converters;

internal abstract class AltitudeConverter : IStringConverter<Altitude>
{
    public static Result<Altitude> Convert(ReadOnlySpan<char> @string) => @string switch
    {
        "NOTAM" => new Altitude(0, AltitudeUnit.Notam),
        "UNKNN" => new Altitude(0, AltitudeUnit.Unknown),
        "UNLTD" => new Altitude(int.MaxValue, AltitudeUnit.Unlimited),
        "NESTB" or "NOTSP" => new Altitude(0, AltitudeUnit.Unspecified),

        _ when @string[0] is 'F' => int.TryParse(@string[2..], out int value)
            ? new Altitude(value, AltitudeUnit.Level)
            : @string[2..],

        _ when @string[0] is 'M' => int.TryParse(@string[1..], out int value)
            ? new Altitude(value, AltitudeUnit.Meters)
            : @string,

        _ when @string[..3] is "GND" => new Altitude(0, AltitudeUnit.Ground),
        _ when @string[..3] is "MSL" => new Altitude(0, AltitudeUnit.Sea),

        _ => int.TryParse(@string, out int value)
            ? new Altitude(value, AltitudeUnit.Feet)
            : @string
    };
}

/// <summary>
/// Converter for <see cref="Comms.Transmitter.Altitude"/> and <see cref="Comms.Transmitter.Altitude2"/> since supplement 19.
/// </summary>
internal abstract class CommAltitudeConverter : IStringConverter<Altitude>
{
    public static Result<Altitude> Convert(ReadOnlySpan<char> @string) => int.TryParse(@string, out int value)
        ? new Altitude(value * 100, AltitudeUnit.Feet)
        : @string;
}
