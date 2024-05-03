namespace Arinc424.Building;

internal static class RecordBuilder<TRecord, TSub> where TRecord : Record424<TSub>, new()
                                                   where TSub : Record424, new()
{
    private static readonly BuildInfo subInfo = new(typeof(TSub));

    internal static TRecord Build(Queue<string> strings)
    {
        var record = RecordBuilder<TRecord>.Build(strings.First());

        while (strings.TryDequeue(out string? @string))
            record.Sequence.Add(RecordBuilder.Build<TSub>(subInfo, @string));

        return record;
    }
}
