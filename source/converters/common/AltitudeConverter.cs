namespace Arinc424.Converters;

internal abstract class AltitudeConverter : IStringConverter<AltitudeConverter, Altitude>
{
    public static Result<Altitude> Convert(ReadOnlySpan<char> @string) => @string switch
    {
        "NOTAM" => new Altitude(0, AltitudeUnit.Notam),
        "UNKNN" => new Altitude(0, AltitudeUnit.Unknown),
        "UNLTD" => new Altitude(int.MaxValue, AltitudeUnit.Unlimited),
        "NESTB" or "NOTSP" => new Altitude(0, AltitudeUnit.Unspecified),

        _ when @string[0] is 'F' => int.TryParse(@string[2..], out int value)
            ? new Altitude(value, AltitudeUnit.Level)
            : $"Altitude '{@string}' is defined as flight level, but '{@string[2..]}' can't be parsed as an integer.",

        _ when @string[0] is 'M' => int.TryParse(@string[1..], out int value)
            ? new Altitude(value, AltitudeUnit.Meters)
            : $"Altitude '{@string}' is defined as meters, but '{@string[1..]}' can't be parsed as an integer.",

        _ when @string[..3] is "GND" => new Altitude(0, AltitudeUnit.Ground),
        _ when @string[..3] is "MSL" => new Altitude(0, AltitudeUnit.Sea),

        _ => int.TryParse(@string, out int value)
            ? new Altitude(value, AltitudeUnit.Feet)
            : $"Altitude '{@string}' is defined as feet, but can't be parsed as an integer."
    };
}
