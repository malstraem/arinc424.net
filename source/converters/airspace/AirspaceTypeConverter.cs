using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Converters;

/// <summary>
/// Converter for <see cref="AirspaceType"/>.
/// </summary>
internal abstract class AirspaceTypeConverter : ICharConverter<AirspaceTypeConverter, AirspaceType>
{
    public static AirspaceType Convert(char @char) => @char switch
    {
        'A' => AirspaceType.ClassC,
        'C' => AirspaceType.ControlArea,
        'M' => AirspaceType.TerminalControlArea,
        'R' => AirspaceType.RadarZone,
        'T' => AirspaceType.ClassB,
        'Z' => AirspaceType.ControlZone,
        _ => AirspaceType.Unknown
    };
}
