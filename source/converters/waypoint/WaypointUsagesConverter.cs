using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Converters;

internal class WaypointUsagesConverter : IStringConverter<WaypointUsagesConverter, WaypointUsages>
{
    public static WaypointUsages Convert(string @string)
    {
        var first = @string[0] is 'R' ? WaypointUsages.AreaNavigation : WaypointUsages.Unknown;

        char @char = @string[1];

        var second = char.IsWhiteSpace(@char) ? WaypointUsages.TerminalOnly : @char switch
        {
            'B' => WaypointUsages.LowAltitude | WaypointUsages.HighAltitude,
            'H' => WaypointUsages.HighAltitude,
            'L' => WaypointUsages.LowAltitude,
            _ => WaypointUsages.Unknown
        };

        return first | second;
    }
}
