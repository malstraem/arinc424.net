namespace Arinc.Spec424.Records;

[AttributeUsage(AttributeTargets.Property)]
internal class HiddenAttribute : Attribute { }

public record SequencedRecord424<TSubsequence> : Record424 where TSubsequence : Record424
{
    [Hidden]
    public required IReadOnlyList<TSubsequence> Sequences { get; set; }
}
