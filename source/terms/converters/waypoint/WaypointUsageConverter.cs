namespace Arinc.Spec424.Terms.Converters;

internal class WaypointUsageConverter : IStringConverter
{
    public static object Convert(string @string)
    {
        var first = @string[0] is 'R' ? WaypointUsage.AreaNavigation : WaypointUsage.Unknown;

        char @char = @string[1];

        var second = @char switch
        {
            'B' => WaypointUsage.HighLowAltitude,
            'H' => WaypointUsage.HighAltitude,
            'L' => WaypointUsage.LowAltitude,
            _ when char.IsWhiteSpace(@char) => WaypointUsage.TerminalOnly,
            _ => WaypointUsage.Unknown
        };

        return first | second;
    }
}
