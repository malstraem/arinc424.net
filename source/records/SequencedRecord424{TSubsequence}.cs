namespace Arinc.Spec424.Records;

public record SequencedRecord424<TSubsequence> : Record424 where TSubsequence : Record424
{
    public required IReadOnlyList<TSubsequence> Sequences { get; set; }
}
