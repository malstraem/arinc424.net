using Arinc424.Navigation.Terms;

namespace Arinc424.Converters;

[Obsolete("todo separated types")]
internal abstract class OmnidirectionalTypeConverter : IStringConverter<OmnidirectionalTypeConverter, NavaidType>
{
    public static Result<NavaidType> Convert(ReadOnlySpan<char> @string) => @string[0] switch
    {
        'V' => NavaidType.Omnidirectional,
        _ => NavaidType.Unknown
    }
    | @string[1] switch
    {
        'D' => NavaidType.DistanceEquipment,
        'T' => NavaidType.Tactical,
        'M' => NavaidType.MilitaryTactical,
        'I' => NavaidType.InstrumentLanding,
        'N' => NavaidType.MicrowaveDistanceEquipmentN,
        'P' => NavaidType.MicrowaveDistanceEquipmentP,
        _ => NavaidType.Unknown
    };
}
