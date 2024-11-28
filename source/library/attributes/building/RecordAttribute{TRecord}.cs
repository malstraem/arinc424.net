using Arinc424.Building;

namespace Arinc424.Attributes;

internal abstract class RecordAttribute : Attribute
{
    internal abstract RecordInfo GetInfo(Supplement supplement);
}

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
internal sealed class RecordAttribute<TRecord> : RecordAttribute where TRecord : Record424, new()
{
    internal override RecordInfo GetInfo(Supplement supplement) => RecordInfo.Create<TRecord>(supplement);
}
