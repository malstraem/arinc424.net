namespace Arinc.Spec424.Building;

internal static class RecordBuilder
{
    internal static TRecord Build<TRecord>(BuildInfo info, string @string) where TRecord : Record424, new()
    {
        TRecord record = new() { Source = @string };

        foreach (var rangeInfo in info.RangeInfo)
        {
            object? value;

            string @field = @string[rangeInfo.Range];

            value = string.IsNullOrWhiteSpace(@field)
                ? null
                : rangeInfo.Decode is not null
                    ? rangeInfo.Decode.Convert(@field)
                    : @field.Trim();

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
