using Arinc424.Building;
using Arinc424.Diagnostics;

namespace Arinc424.Attributes;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
internal abstract class RecordAttribute(Type type) : InfoAttribute(type)
{
    internal abstract Record424 Build(string @string, Queue<Diagnostic> diagnostics);
}

internal sealed class RecordAttribute<TRecord>() : RecordAttribute(typeof(TRecord)) where TRecord : Record424, new()
{
    private readonly BuildInfo<TRecord> info = new(typeof(TRecord).GetProperties());

    internal override Record424 Build(string @string, Queue<Diagnostic> diagnostics) => RecordBuilder<TRecord>.Build(@string, info, diagnostics);
}
