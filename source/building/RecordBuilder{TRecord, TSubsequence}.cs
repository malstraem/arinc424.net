using Arinc.Spec424.Records;

namespace Arinc.Spec424.Building;

internal static class RecordBuilder<TRecord, TSubsequence> where TRecord : SequencedRecord424<TSubsequence>, new()
                                                           where TSubsequence : Record424, new()
{
    private static readonly BuildInfo subsequenceInfo = new(typeof(TSubsequence), typeof(TRecord));

    internal static TRecord Build(Queue<string> strings)
    {
        List<TSubsequence> subsequences = [];

        var record = RecordBuilder<TRecord>.Build(strings.First());

        foreach (string @string in strings)
            subsequences.Add(RecordBuilder.Build<TSubsequence>(subsequenceInfo, @string));

        record.Subsequences = subsequences;

        return record;
    }
}
