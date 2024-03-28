using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Converters;

internal class AltitudeConverter : IStringConverter
{
    public static object Convert(string @string) => @string[0] is 'F' ? (int.Parse(@string[2..]), AltitudeUnit.Level) : @string switch
    {
        "NESTB" => (0, AltitudeUnit.NotEstablished),
        "UNLTD" => (int.MaxValue, AltitudeUnit.Unlimited),
        _ => (0, AltitudeUnit.Unknown),
    };
}
