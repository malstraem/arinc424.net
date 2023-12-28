using Arinc.Spec424.Records;

namespace Arinc.Spec424.Building;

internal static class RecordBuilder<TRecord, TSubsequence> where TRecord : SequencedRecord424<TSubsequence>
                                                           where TSubsequence : Record424
{
    private readonly static BuildInfo subsequenceInfo = new(typeof(TSubsequence), typeof(TRecord));

    internal static TRecord Build(Queue<string> strings)
    {
        List<TSubsequence> sequences = [];

        var record = RecordBuilder<TRecord>.Build(strings.First());

        while (strings.TryDequeue(out string? @string))
            sequences.Add((TSubsequence)RecordBuilder.Build(subsequenceInfo, @string));

        record.Sequences = sequences;

        return record;
    }
}
