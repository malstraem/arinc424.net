using Arinc424.Airspace.Terms;

namespace Arinc424.Converters;

using static System.Globalization.NumberStyles;

internal abstract class ArcConverter : IStringConverter<Arc>
{
    public static Result<Arc> Convert(ReadOnlySpan<char> @string)
    {
        string? problem = null;

        var sub = @string[..19];

        var coordinates = CoordinatesConverter.Convert(sub);

        if (coordinates.Invalid)
            problem = coordinates.Problem;

        float? distance = null;

        sub = @string[19..23];

        if (sub.IsWhiteSpace())
            distance = null;
        else if (!float.TryParse(sub, None, null, out float value))
            problem += $"Distance '{sub}' can't be parsed.";
        else
            distance = value / 10;

        float? bearing = null;

        sub = @string[23..];

        if (sub.IsWhiteSpace())
            bearing = null;
        else if (!float.TryParse(sub, None, null, out float value))
            problem += $"Bearing '{sub}' can't be parsed.";
        else
            bearing = value / 10;

        return problem is null ? new Arc(coordinates.Value, distance, bearing) : problem;
    }
}
