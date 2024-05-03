using Arinc424.Comms.Terms;

namespace Arinc424.Converters;

internal abstract class ModulationConverter : ICharConverter<ModulationConverter, Modulation>
{
    public static Modulation Convert(char @char) => @char switch
    {
        'A' => Modulation.Amplitude,
        'F' => Modulation.Frequency,
        _ => Modulation.Unknown
    };
}
