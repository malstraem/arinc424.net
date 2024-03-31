using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Converters;

internal class WaypointNameFormatsConverter : IStringConverter<WaypointNameFormatsConverter, WaypointNameFormats>
{
    public static WaypointNameFormats Convert(string @string) => @string[0] switch
    {
        'A' => WaypointNameFormats.Abeam,
        'B' => WaypointNameFormats.BearingDistance,
        'D' => WaypointNameFormats.AirportName,
        'F' => WaypointNameFormats.FlightInfoRegion,
        'H' => WaypointNameFormats.PhoneticLetterName,
        'I' => WaypointNameFormats.AirportIdentifier,
        'L' => WaypointNameFormats.LatitudeLongitude,
        'M' => WaypointNameFormats.MultipleWordName,
        'N' => WaypointNameFormats.NavaidIdentifier,
        'P' => WaypointNameFormats.FiveLetterName,
        'Q' => WaypointNameFormats.LessFiveLetterName,
        'R' => WaypointNameFormats.MoreFiveLetterName,
        'T' => WaypointNameFormats.AirportRunway,
        'U' => WaypointNameFormats.UpperInfoRegion,
        _ => WaypointNameFormats.Unknown
    }
    | @string[1] switch
    {
        'O' => WaypointNameFormats.LocalizerOfficialFive,
        'M' => WaypointNameFormats.LocalizerUnofficialFive,
        _ => WaypointNameFormats.Unknown
    };
}
