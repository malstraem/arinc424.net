using Arinc424.Waypoints.Terms;

namespace Arinc424.Converters;

internal abstract class WaypointUsagesConverter : IStringConverter<WaypointUsagesConverter, WaypointUsages>
{
    public static WaypointUsages Convert(ReadOnlySpan<char> @string)
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