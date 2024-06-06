using Arinc424.Tables.Terms;

namespace Arinc424.Converters;

internal abstract class LevelRangeConverter : IStringConverter<LevelRangeConverter, LevelRange>
{
    public static Result<LevelRange> Convert(ReadOnlySpan<char> @string)
    {
        string? problem = null;

        Altitude from = default, separation = default, to = default;

        var altitude = AltitudeConverter.Convert(@string[..5]);

        if (altitude.IsError)
            problem = altitude.Problem;
        else
            from = altitude.Value;

        altitude = AltitudeConverter.Convert(@string[5..10]);

        if (altitude.IsError)
            problem += altitude.Problem;
        else
            separation = altitude.Value;

        altitude = AltitudeConverter.Convert(@string[10..15]);

        if (altitude.IsError)
            problem += altitude.Problem;
        else
            to = altitude.Value;

        if (problem is not null)
            return problem;

        if (from.Unit is AltitudeUnit.Meters)
            from *= 10;

        if (separation.Unit is AltitudeUnit.Meters)
            separation *= 10;

        if (to.Unit is AltitudeUnit.Meters)
            to *= 10;

        return new LevelRange(from, separation, to);
    }
}
