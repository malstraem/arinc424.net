using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Converters;

public abstract class AltitudeConverter : IStringConverter<AltitudeConverter, (int, AltitudeUnit)>
{
    public static (int, AltitudeUnit) Convert(string @string) => @string[0] is 'F' ? (int.Parse(@string[2..]), AltitudeUnit.Level) : @string switch
    {
        "NESTB" => (0, AltitudeUnit.NotEstablished),
        "UNLTD" => (int.MaxValue, AltitudeUnit.Unlimited),
        _ => (0, AltitudeUnit.Unknown),
    };
}
