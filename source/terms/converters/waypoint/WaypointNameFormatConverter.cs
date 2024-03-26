namespace Arinc.Spec424.Terms.Converters;

internal class WaypointNameFormatConverter : IStringConverter
{
    public static object Convert(string @string)
    {
        var first = @string[0] switch
        {
            'A' => WaypointNameFormat.Abeam,
            'B' => WaypointNameFormat.BearingDistance,
            'D' => WaypointNameFormat.AirportName,
            'F' => WaypointNameFormat.FlightInfoRegion,
            'H' => WaypointNameFormat.PhoneticLetterName,
            'I' => WaypointNameFormat.AirportIdentifier,
            'L' => WaypointNameFormat.LatitudeLongitude,
            'M' => WaypointNameFormat.MultipleWordName,
            'N' => WaypointNameFormat.NavaidIdentifier,
            'P' => WaypointNameFormat.FiveLetterName,
            'Q' => WaypointNameFormat.LessFiveLetterName,
            'R' => WaypointNameFormat.MoreFiveLetterName,
            'T' => WaypointNameFormat.AirportRunway,
            'U' => WaypointNameFormat.UpperInfoRegion,
            _ => WaypointNameFormat.Unknown
        };

        var second = @string[1] switch
        {
            'O' => WaypointNameFormat.LocalizerOfficialFive,
            'M' => WaypointNameFormat.LocalizerUnofficialFive,
            _ => WaypointNameFormat.Unknown
        };

        return first | second;
    }
}
