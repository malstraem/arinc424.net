namespace Arinc424.Attributes;

using Building;

internal abstract class RecordAttribute : Attribute
{
    internal abstract RecordType GetType(Supplement supplement);
}

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
internal sealed class RecordAttribute<R> : RecordAttribute
    where R : Record424
{
    internal override RecordType GetType(Supplement supplement)
        => RecordType.Create<R>(supplement);
}
