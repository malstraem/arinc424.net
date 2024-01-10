namespace Arinc.Spec424.Records;

public class SequencedRecord424<TSubsequence> : Record424 where TSubsequence : Record424
{
    public required IReadOnlyList<TSubsequence> Sequences { get; set; }
}
