using Arinc424.Comms.Terms;

namespace Arinc424.Converters;

internal abstract class SectorConverter : IStringConverter<SectorConverter, Sector>
{
    public static Sector Convert(ReadOnlySpan<char> @string)
    {
        var start = @string[0..3];
        var end = @string[3..6];

        return new
        (
            start: start.IsWhiteSpace() ? 0 : int.Parse(start),
            end: end.IsWhiteSpace() ? 0 : int.Parse(end)
        );
    }
}
