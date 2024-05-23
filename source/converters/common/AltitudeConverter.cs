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
            : new Result<Altitude>($"Altitude '{@string}' is defined as flight level, but the integer component '{@string[2..]}' cannot be parsed."),

        _ when @string[..3] is "GND" => new Altitude(0, AltitudeUnit.Ground),
        _ when @string[..3] is "MSL" => new Altitude(0, AltitudeUnit.Sea),

        _ => int.TryParse(@string, out int value)
            ? new Altitude(value, AltitudeUnit.Feet)
            : new Result<Altitude>($"Altitude '{@string}' is defined as feet, but the integer cannot be parsed.")
    };
    /* @string switch
    {
        "NOTAM" => new(0, AltitudeUnit.Notam),
        "UNKNN" => new(0, AltitudeUnit.Unknown),
        "UNLTD" => new(int.MaxValue, AltitudeUnit.Unlimited),
        "NESTB" or "NOTSP" => new(0, AltitudeUnit.Unspecified),
        _ when @string[0] is 'F' => new(int.Parse(@string[2..]), AltitudeUnit.Level),
        _ when @string.Trim() is "GND" => new(0, AltitudeUnit.Ground),
        _ when @string.Trim() is "MSL" => new(0, AltitudeUnit.Sea),
        _ => new(int.Parse(@string), AltitudeUnit.Feet)
    }*/
}
