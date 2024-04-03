using Arinc424.Airspace;

namespace Arinc424.Converters;

internal abstract class ArcConverter : IStringConverter<ArcConverter, Arc>
{
    public static Arc Convert(ReadOnlySpan<char> @string)
    {
        Arc arc = new()
        {
            Latitude = LatitudeConverter.Convert(@string[..9]),
            Longitude = LongitudeConverter.Convert(@string[9..19]),
        };

        var distance = @string[19..23];
        var bearing = @string[23..];

        if (!MemoryExtensions.IsWhiteSpace(distance))
            arc.Distance = float.Parse(distance) / 10;

        if (!MemoryExtensions.IsWhiteSpace(bearing))
            arc.Bearing = float.Parse(bearing) / 10;

        return arc;
    }
}
