namespace Arinc.Spec424.Records;

#pragma warning disable CS8618

public abstract class Record424<TSub> : Record424 where TSub : Record424
{
    public IReadOnlyList<TSub> Sequence { get; set; }
}
