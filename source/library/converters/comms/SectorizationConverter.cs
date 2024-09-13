namespace Arinc424.Converters;

internal abstract class SectorizationConverter : IStringConverter<Sectorization>
{
    public static Result<Sectorization> Convert(ReadOnlySpan<char> @string)
    {
        var start = IntConverter.Convert(@string[0..3]);

        if (start.Invalid)
            return start.Bad;

        var end = IntConverter.Convert(@string[3..6]);

        return end.Invalid ? end.Bad : new Sectorization(start.Value, end.Value);
    }
}
