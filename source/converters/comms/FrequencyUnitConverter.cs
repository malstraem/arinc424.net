using Arinc424.Comms.Terms;

namespace Arinc424.Converters;

internal abstract class FrequencyUnitConverter : ICharConverter<FrequencyUnitConverter, FrequencyUnit>
{
    public static FrequencyUnit Convert(char @char) => @char switch
    {
        'L' => FrequencyUnit.Low,
        'M' => FrequencyUnit.Medium,
        'H' => FrequencyUnit.High,
        'K' => FrequencyUnit.VeryHighSpacing100,
        'F' => FrequencyUnit.VeryHighSpacing50,
        'T' => FrequencyUnit.VeryHighSpacing25,
        'V' => FrequencyUnit.VeryHighNonStandardSpacing,
        'U' => FrequencyUnit.UltraHigh,
        'C' => FrequencyUnit.Channel,
        'D' => FrequencyUnit.Digital,
        _ => FrequencyUnit.Unknown
    };
}
