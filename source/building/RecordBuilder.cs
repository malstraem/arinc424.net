namespace Arinc424.Building;

internal static class RecordBuilder
{
    internal static TRecord Build<TRecord>(BuildInfo info, string @string) where TRecord : Record424, new()
    {
        TRecord record = new() { Source = @string };

        ReadOnlySpan<char> chars = @string;

        foreach (var rangeInfo in info.RangeInfo)
        {
            var @field = chars[rangeInfo.Range];

            object? value = @field.IsWhiteSpace()
                ? null
                : rangeInfo.Decode is not null
                    ? rangeInfo.Decode.Convert(@field)
                    : @field.Trim().ToString();

            rangeInfo.Property.SetValue(record, value);
        }

        foreach (var indexInfo in info.IndexInfo)
        {
            char @char = @string[indexInfo.Index];

            object value = indexInfo.Transform is not null ? indexInfo.Transform.Convert(@char) : @char;

            indexInfo.Property.SetValue(record, value);
        }
        return record;
    }
}
