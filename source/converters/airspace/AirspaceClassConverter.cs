using Arinc424.Airspace.Terms;

namespace Arinc424.Converters;

internal abstract class AirspaceClassConverter : ICharConverter<AirspaceClassConverter, AirspaceClass>
{
    public static AirspaceClass Convert(char @char) => @char switch
    {
        'A' => AirspaceClass.Alpha,
        'B' => AirspaceClass.Bravo,
        'C' => AirspaceClass.Charlie,
        'D' => AirspaceClass.Delta,
        'E' => AirspaceClass.Echo,
        'F' => AirspaceClass.Foxtrot,
        'G' => AirspaceClass.Golf,
        _ => AirspaceClass.Unknown
    };
}
