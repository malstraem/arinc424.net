using Arinc424.Diagnostics;

namespace Arinc424.Building;

internal static class RecordBuilder<TRecord, TSub> where TRecord : Record424<TSub>, new()
                                                   where TSub : Record424, new()
{
    internal static TRecord Build(Queue<string> strings, SequenceAttribute info, Queue<Diagnostic> diagnostics)
    {
        var record = RecordBuilder<TRecord>.Build(strings.First(), info, diagnostics);

        while (strings.TryDequeue(out string? @string))
            record.Sequence.Add(RecordBuilder<TSub>.Build(@string, info.SubInfo, diagnostics));

        return record;
    }
}
