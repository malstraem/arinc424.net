using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Converters;

internal abstract class AltitudeConverter : IStringConverter<AltitudeConverter, (int, AltitudeUnit)>
{
    public static (int, AltitudeUnit) Convert(string @string) => @string switch
    {
        "NOTAM" => (0, AltitudeUnit.Notam),
        "UNKNN" => (0, AltitudeUnit.Unknown),
        "UNLTD" => (int.MaxValue, AltitudeUnit.Unlimited),
        "NESTB" or "NOTSP" => (0, AltitudeUnit.NotSpecified),
        _ when @string[0] is 'F' => (int.Parse(@string[2..]), AltitudeUnit.Level),
        _ when @string.Trim() is "GND" => (0, AltitudeUnit.Ground),
        _ when @string.Trim() is "MSL" => (0, AltitudeUnit.Sea),
        _ => (int.Parse(@string), AltitudeUnit.Feet)
    };
}
