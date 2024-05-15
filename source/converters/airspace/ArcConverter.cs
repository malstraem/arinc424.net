using Arinc424.Airspace;

namespace Arinc424.Converters;

internal abstract class ArcConverter : IStringConverter<ArcConverter, Arc>
{
    public static Arc Convert(ReadOnlySpan<char> @string)
    {
        Arc arc = new() { Coordinates = CoordinatesConverter.Convert(@string[..19]) };

        var distance = @string[19..23];
        var bearing = @string[23..];

        if (!distance.IsWhiteSpace())
            arc.Distance = float.Parse(distance) / 10;

        if (!bearing.IsWhiteSpace())
            arc.Bearing = float.Parse(bearing) / 10;

        return arc;
    }
}
