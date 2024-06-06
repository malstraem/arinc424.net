using Arinc424.Airspace.Terms;

namespace Arinc424.Converters;

internal abstract class ArcConverter : IStringConverter<ArcConverter, Arc>
{
    [Obsolete("todo")]
    public static Result<Arc> Convert(ReadOnlySpan<char> @string)
    {
        var sub = @string[..19];

        var coordinates = CoordinatesConverter.Convert(sub);

        if (coordinates.IsError)
            return new(coordinates.Problem!);

        float? distance;

        sub = @string[19..23];

        if (sub.IsWhiteSpace())
            distance = null;
        else if (!float.TryParse(sub, out float value))
            return new($"Distance '{sub}' cannot be parsed.");
        else
            distance = value / 10;

        float? bearing;

        sub = @string[23..];

        if (sub.IsWhiteSpace())
            bearing = null;
        else if (!float.TryParse(sub, out float value))
            return new($"Distance '{sub}' cannot be parsed.");
        else
            bearing = value / 10;

        return new Arc(coordinates.Value, distance, bearing);
    }
}
