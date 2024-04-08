namespace Arinc424.Converters;

internal class AltitudeDescriptionConverter : ICharConverter<AltitudeDescriptionConverter, AltitudeDescription>
{
    public static AltitudeDescription Convert(char @char) => char.IsWhiteSpace(@char) ? AltitudeDescription.AtFirst : @char switch
    {
        '+' => AltitudeDescription.AtAboveFirst,
        '-' => AltitudeDescription.AtBelowFirst,
        'B' => AltitudeDescription.AtAboveAtBelow,
        'C' => AltitudeDescription.AtAboveSecond,
        'D' => AltitudeDescription.AtAboveSecondNotBefore,
        'G' => AltitudeDescription.GlideSlope,
        'V' => AltitudeDescription.AtVerticalSecondAtAboveFirst,
        'X' => AltitudeDescription.AtVerticalSecondAtFirst,
        'Y' => AltitudeDescription.AtVerticalSecondAtBelowFirst,
        _ => AltitudeDescription.Unknown
    };
}
