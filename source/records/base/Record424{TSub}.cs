namespace Arinc.Spec424.Records;

public abstract class Record424<TSub> : Record424 where TSub : Record424
{
    public List<TSub> Sequence { get; set; } = [];
}
