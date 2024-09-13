using Arinc424.Tables.Terms;

namespace Arinc424.Converters;

internal abstract class LevelConverter : IStringConverter<Level>
{
    public static Result<Level> Convert(ReadOnlySpan<char> @string)
    {
        var altitude = AltitudeConverter.Convert(@string[..5]);

        if (altitude.Invalid)
            return altitude.Bad;

        var from = altitude.Value;

        altitude = AltitudeConverter.Convert(@string[5..10]);

        if (altitude.Invalid)
            return altitude.Bad;

        var separation = altitude.Value;

        altitude = AltitudeConverter.Convert(@string[10..15]);

        if (altitude.Invalid)
            return altitude.Bad;

        var to = altitude.Value;

        if (from.Unit is AltitudeUnit.Meters)
            from *= 10;

        if (separation.Unit is AltitudeUnit.Meters)
            separation *= 10;

        if (to.Unit is AltitudeUnit.Meters)
            to *= 10;

        return new Level(from, separation, to);
    }
}
