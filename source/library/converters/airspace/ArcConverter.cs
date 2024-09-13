using Arinc424.Airspace.Terms;

namespace Arinc424.Converters;

using static System.Globalization.NumberStyles;

internal abstract class ArcConverter : IStringConverter<Arc>
{
    public static Result<Arc> Convert(ReadOnlySpan<char> @string)
    {
        var sub = @string[..19];

        var coordinates = CoordinatesConverter.Convert(sub);

        if (coordinates.Invalid)
            return coordinates.Bad;

        float? distance;

        sub = @string[19..23];

        if (sub.IsWhiteSpace())
            distance = null;
        else if (!float.TryParse(sub, None, null, out float value))
            return sub;
        else
            distance = value / 10;

        float? bearing;

        sub = @string[23..];

        if (sub.IsWhiteSpace())
            bearing = null;
        else if (!float.TryParse(sub, None, null, out float value))
            return sub;
        else
            bearing = value / 10;

        return new Arc(coordinates.Value, distance, bearing);
    }
}
