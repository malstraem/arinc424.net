namespace Arinc424.Building;

internal static class RecordBuilder<TRecord, TSub> where TRecord : Record424<TSub>, new()
                                                   where TSub : Record424, new()
{
    internal static TRecord Build(Queue<string> strings, BuildAttribute info, BuildAttribute subInfo)
    {
        var record = RecordBuilder<TRecord>.Build(strings.First(), info);

        while (strings.TryDequeue(out string? @string))
            record.Sequence.Add(RecordBuilder<TSub>.Build(@string, subInfo));

        return record;
    }
}
