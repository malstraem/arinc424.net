using Arinc424.Building;

namespace Arinc424.Attributes;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
internal abstract class InfoAttribute : Attribute
{
    internal abstract RecordInfo GetInfo(Supplement supplement);
}

internal class RecordAttribute<TRecord> : InfoAttribute where TRecord : Record424, new()
{
    internal override RecordInfo GetInfo(Supplement supplement) => new RecordInfo<TRecord>(supplement);
}

internal sealed class SequenceAttribute<TSequence, TSub> : RecordAttribute<TSequence>
    where TSequence : Record424<TSub>, new()
    where TSub : Record424, new()
{
    internal override RecordInfo GetInfo(Supplement supplement) => new RecordInfo<TSequence, TSub>(supplement);
}
