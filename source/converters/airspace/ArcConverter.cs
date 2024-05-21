using Arinc424.Airspace.Terms;

namespace Arinc424.Converters;

internal abstract class ArcConverter : IStringConverter<ArcConverter, Arc>
{
    [Obsolete("todo")]
    public static Arc Convert(ReadOnlySpan<char> @string)
    {
        var coordinates = @string[..19];
        var distance = @string[19..23];
        var bearing = @string[23..];

        return new
        (
            CoordinatesConverter.Convert(coordinates),
            distance.IsWhiteSpace() ? null : float.Parse(distance) / 10,
            bearing.IsWhiteSpace() ? null : float.Parse(bearing) / 10
        );
    }
}
