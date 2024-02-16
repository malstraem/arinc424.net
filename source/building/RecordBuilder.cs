namespace Arinc.Spec424.Building;

internal static class RecordBuilder
{
    internal static TRecord Build<TRecord>(BuildInfo info, string @string) where TRecord : Record424, new()
    {
        TRecord record = new();

        foreach (var rangeInfo in info.RangeInfo)
        {
            string? trimmed = @string[rangeInfo.Range].Trim();

            if (trimmed.Length == 0)
                trimmed = null;

            object? value = rangeInfo.Decode is not null && trimmed is not null ? rangeInfo.Decode.Convert(@trimmed) : @trimmed;

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
