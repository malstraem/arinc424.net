using Arinc424.Diagnostics;

namespace Arinc424.Building;

internal static class RecordBuilder<TRecord, TSub> where TRecord : Record424<TSub>, new()
                                                   where TSub : Record424, new()
{
    internal static TRecord Build(Queue<string> strings, BuildInfo<TRecord> info, BuildInfo<TSub> subInfo, Queue<Diagnostic> diagnostics)
    {
        var record = RecordBuilder<TRecord>.Build(strings.First(), info, diagnostics);

        var sequence = record.Sequence = new List<TSub>(strings.Count);

        while (strings.TryDequeue(out string? @string))
            sequence.Add(RecordBuilder<TSub>.Build(@string, subInfo, diagnostics));

        return record;
    }
}
