using Arinc424.Diagnostics;

namespace Arinc424.Building;

internal static class RecordBuilder<TRecord> where TRecord : Record424, new()
{
    [Obsolete("todo")]
    internal static TRecord Build(string @string, BuildAttribute info, Queue<Diagnostic> diagnostics)
    {
        TRecord record = new() { Source = @string };

        ReadOnlySpan<char> chars = @string;

        foreach (var indexInfo in info.IndexInfo)
            indexInfo.Process(record, chars);

        foreach (var rangeInfo in info.RangeInfo)
            rangeInfo.Process(record, chars, diagnostics);

        return record;
    }
}
