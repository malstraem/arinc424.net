using Arinc424.Building;

namespace Arinc424.Attributes;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
internal abstract class RecordAttribute(Type type) : InfoAttribute(type, type.GetProperties())
{
    internal abstract Record424 Build(string @string);
}

internal class RecordAttribute<TRecord>() : RecordAttribute(typeof(TRecord)) where TRecord : Record424, new()
{
    internal override Record424 Build(string @string) => RecordBuilder<TRecord>.Build(@string);
}