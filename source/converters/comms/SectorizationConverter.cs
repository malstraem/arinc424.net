namespace Arinc424.Converters;

internal abstract class SectorizationConverter : IStringConverter<SectorizationConverter, Sectorization>
{
    [Obsolete("todo")]
    public static Result<Sectorization> Convert(ReadOnlySpan<char> @string)
    {
        var start = IntConverter.Convert(@string[0..3]);

        if (start.IsError)
            return new(start.Problem!);

        var end = IntConverter.Convert(@string[3..6]);

        return start.IsError ? new Result<Sectorization>(end.Problem!) : new Sectorization(start.Value, end.Value);
    }
}
