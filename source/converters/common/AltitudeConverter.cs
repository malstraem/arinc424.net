namespace Arinc424.Converters;

internal abstract class AltitudeConverter : IStringConverter<AltitudeConverter, Altitude>
{
    public static Altitude Convert(ReadOnlySpan<char> @string) => @string switch
    {
        "NOTAM" => new(0, AltitudeUnit.Notam),
        "UNKNN" => new(0, AltitudeUnit.Unknown),
        "UNLTD" => new(int.MaxValue, AltitudeUnit.Unlimited),
        "NESTB" or "NOTSP" => new(0, AltitudeUnit.Unspecified),
        _ when @string[0] is 'F' => new(int.Parse(@string[2..]), AltitudeUnit.Level),
        _ when @string.Trim() is "GND" => new(0, AltitudeUnit.Ground),
        _ when @string.Trim() is "MSL" => new(0, AltitudeUnit.Sea),
        _ => new(int.Parse(@string), AltitudeUnit.Feet)
    };
}
