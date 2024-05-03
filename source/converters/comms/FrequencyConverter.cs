using Arinc424.Comms.Terms;

namespace Arinc424.Converters;

internal abstract class FrequencyConverter : IStringConverter<FrequencyConverter, Frequency>
{
    public static Frequency Convert(ReadOnlySpan<char> @string)
    {
        var unit = FrequencyUnitConverter.Convert(@string[14]);

        var transmit = @string[0..7];
        var receive = @string[7..14];

        return new
        (
            receive: receive.IsWhiteSpace() ? 0 : float.Parse(receive) / (unit is FrequencyUnit.High or FrequencyUnit.UltraHigh ? 100 : 1000),
            transmit: transmit.IsWhiteSpace() ? 0 : float.Parse(transmit) / (unit is FrequencyUnit.High or FrequencyUnit.UltraHigh ? 100 : 1000),
            unit: unit
        );
    }
}
