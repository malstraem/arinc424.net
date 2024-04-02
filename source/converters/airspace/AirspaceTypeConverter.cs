using Arinc424.Airspace.Terms;

namespace Arinc424.Converters;

/// <summary>
/// Converter for <see cref="AirspaceType"/>.
/// </summary>
internal abstract class AirspaceTypeConverter : ICharConverter<AirspaceTypeConverter, AirspaceType>
{
    public static AirspaceType Convert(char @char) => @char switch
    {
        'A' => AirspaceType.Charlie,
        'C' => AirspaceType.ControlArea,
        'M' => AirspaceType.TerminalControlArea,
        'R' => AirspaceType.RadarZone,
        'T' => AirspaceType.Bravo,
        'Z' => AirspaceType.ControlZone,
        _ => AirspaceType.Unknown
    };
}
