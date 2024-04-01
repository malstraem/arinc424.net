using Arinc.Spec424.Records;

namespace Arinc.Spec424.Converters;

internal abstract class ArcConverter : IStringConverter<ArcConverter, Arc>
{
    public static Arc Convert(string @string)
    {
        Arc arc = new()
        {
            Latitude = LatitudeConverter.Convert(@string[..9]),
            Longitude = LongitudeConverter.Convert(@string[9..19]),
        };

        string distance = @string[19..23];
        string bearing = @string[23..];

        if (!string.IsNullOrWhiteSpace(distance))
            arc.Distance = float.Parse(distance) / 10;

        if (!string.IsNullOrWhiteSpace(bearing))
            arc.Bearing = float.Parse(bearing) / 10;

        return arc;
    }
}
