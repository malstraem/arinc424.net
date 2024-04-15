using Arinc424.Building;

namespace Arinc424.Attributes;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
internal abstract class RecordAttribute : InfoAttribute
{
    internal RecordAttribute(Type type) : base(type) { }

    internal abstract Record424 Build(string @string);
}

internal class RecordAttribute<TRecord> : RecordAttribute where TRecord : Record424, new()
{
    internal RecordAttribute() : base(typeof(TRecord)) { }

    internal override Record424 Build(string @string) => RecordBuilder<TRecord>.Build(@string);
}
