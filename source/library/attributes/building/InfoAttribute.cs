using Arinc424.Building;

namespace Arinc424.Attributes;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
internal abstract class InfoAttribute : Attribute
{
    internal abstract IEnumerable<RecordInfo> GetInfo(Supplement supplement);
}

internal class RecordAttribute<TRecord> : InfoAttribute where TRecord : Record424, new()
{
    internal override IEnumerable<RecordInfo> GetInfo(Supplement supplement) => RecordInfo.Create<TRecord>(supplement).DuplicateBySection();
}
