namespace Arinc.Spec424.Records;

#pragma warning disable CS8618

public abstract class SequencedRecord424<TSubsequence> : Record424 where TSubsequence : Record424
{
    public IReadOnlyList<TSubsequence> Subsequences { get; set; }
}
