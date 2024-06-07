namespace Arinc424.Converters;

internal abstract class FrequencyConverter : IStringConverter<Frequency>
{
    public static Result<Frequency> Convert(ReadOnlySpan<char> @string)
    {
        var unit = FrequencyUnitConverter.Convert(@string[14]);

        float? transmit, receive;

        var sub = @string[0..7];

        if (float.TryParse(sub, out float value))
            transmit = value;
        else if (sub.IsWhiteSpace())
            transmit = null;
        else
            return $"Transmit frequency '{sub}' can't be parsed.";

        sub = @string[7..14];

        if (float.TryParse(sub, out value))
            receive = value;
        else if (sub.IsWhiteSpace())
            receive = null;
        else
            return $"Receive frequency '{sub}' can't be parsed.";

        return new Frequency
        (
            receive: receive / (unit is FrequencyUnit.High or FrequencyUnit.UltraHigh ? 100 : 1000),
            transmit: transmit / (unit is FrequencyUnit.High or FrequencyUnit.UltraHigh ? 100 : 1000),
            unit: unit
        );
    }
}
