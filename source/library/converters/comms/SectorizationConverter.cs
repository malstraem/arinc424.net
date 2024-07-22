namespace Arinc424.Converters;

internal abstract class SectorizationConverter : IStringConverter<Sectorization>
{
    public static Result<Sectorization> Convert(ReadOnlySpan<char> @string)
    {
        string? problem = null;

        var start = IntConverter.Convert(@string[0..3]);

        if (start.Invalid)
            problem = start.Problem;

        var end = IntConverter.Convert(@string[3..6]);

        if (end.Invalid)
            problem += end.Problem;

        return problem is null ? new Sectorization(start.Value, end.Value) : problem;
    }
}
