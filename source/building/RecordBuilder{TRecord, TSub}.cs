using Arinc.Spec424.Records;

namespace Arinc.Spec424.Building;

internal static class RecordBuilder<TRecord, TSub> where TRecord : Record424<TSub>, new()
                                                   where TSub : Record424, new()
{
    private static readonly BuildInfo subsequenceInfo = new(typeof(TSub), typeof(TRecord));

    internal static TRecord Build(Queue<string> strings)
    {
        List<TSub> sequence = [];

        var record = RecordBuilder<TRecord>.Build(strings.First());

        foreach (string @string in strings)
            sequence.Add(RecordBuilder.Build<TSub>(subsequenceInfo, @string));

        record.Sequence = sequence;

        return record;
    }
}
