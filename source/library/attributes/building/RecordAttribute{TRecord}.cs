namespace Arinc424.Attributes;

using Building;

internal abstract class RecordAttribute : Attribute
{
    internal abstract RecordType GetType(Supplement supplement);
}

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
internal sealed class RecordAttribute<TRecord> : RecordAttribute
    where TRecord : Record424, new()
{
    internal override RecordType GetType(Supplement supplement)
        => RecordType.Create<TRecord>(supplement);
}
