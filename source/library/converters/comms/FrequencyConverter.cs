namespace Arinc424.Converters;

using static System.Globalization.NumberStyles;

/// <summary>
/// Converter for <see cref="Frequency"/> since supplement 19.
/// </summary>
internal abstract class FrequencyConverterV19 : IStringConverter<Frequency>
{
    public static Result<Frequency> Convert(ReadOnlySpan<char> @string)
    {
        var result = FrequencyUnitConverter.Convert(@string[14]);

        if (result.Invalid)
            return result.Bad;

        var unit = result.Value;

        float? transmit, receive;

        var sub = @string[0..7];

        if (sub.IsWhiteSpace())
            transmit = null;
        else if (float.TryParse(sub, None, null, out float value))
            transmit = value;
        else
            return sub;

        sub = @string[7..14];

        if (sub.IsWhiteSpace())
            receive = null;
        else if (float.TryParse(sub, None, null, out float value))
            receive = value;
        else
            return sub;

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
        var result = FrequencyUnitConverter.Convert(@string[8]);

        if (result.Invalid)
            return result.Bad;

        var unit = result.Value;

        float? transmit = null, receive = null;

        var sub = @string[0..7];

        if (!float.TryParse(sub, None, null, out float value))
            return sub.IsWhiteSpace() ? new Frequency() : sub;

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
