namespace Arinc424.Converters;

using static System.Globalization.NumberStyles;

/// <summary>
/// Converter for <see cref="Frequency"/> since supplement 19.
/// </summary>
internal abstract class FrequencyConverterV19 : IStringConverter<Frequency>
{
    public static Result<Frequency> Convert(ReadOnlySpan<char> @string)
    {
        var unit = FrequencyUnitConverter.Convert(@string[14]);

        float? transmit, receive;

        var sub = @string[0..7];

        if (float.TryParse(sub, None, null, out float value))
            transmit = value;
        else if (sub.IsWhiteSpace())
            transmit = null;
        else
            return $"Transmit frequency '{sub}' can't be parsed.";

        sub = @string[7..14];

        if (float.TryParse(sub, None, null, out value))
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

internal abstract class FrequencyConverter : IStringConverter<Frequency>
{
    public static Result<Frequency> Convert(ReadOnlySpan<char> @string)
    {
        var unit = FrequencyUnitConverter.Convert(@string[8]);

        float? transmit = null, receive = null;

        var sub = @string[0..7];

        if (!float.TryParse(sub, None, null, out float value))
            return sub.IsWhiteSpace() ? new Frequency() : $"Frequency '{sub}' can't be parsed.";

        char guard = @string[7];

        if (guard is 'G')
        {
            receive = value;
            transmit = null;
        }
        else if (guard is 'T')
        {
            transmit = value;
            receive = null;
        }
        else if (char.IsWhiteSpace(guard))
        {
            transmit = receive = value;
        }

        return new Frequency
        (
            receive: receive / (unit is FrequencyUnit.High or FrequencyUnit.UltraHigh ? 100 : 1000),
            transmit: transmit / (unit is FrequencyUnit.High or FrequencyUnit.UltraHigh ? 100 : 1000),
            unit: unit
        );
    }
}
