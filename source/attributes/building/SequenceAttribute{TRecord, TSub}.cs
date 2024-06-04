using System.Reflection;

using Arinc424.Building;
using Arinc424.Diagnostics;

namespace Arinc424.Attributes;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
internal abstract class SequenceAttribute : InfoAttribute
{
    internal Range Range { get; }

    internal LinksAttribute SubLinks { get; }

    internal SequenceAttribute(Type type, Type subType) : base(type, type.GetProperties())
    {
        Range = type.GetCustomAttribute<SequencedAttribute>()!.Range;

        SubLinks = new LinksAttribute(subType, subType.GetProperties());
    }

    internal abstract Record424 Build(Queue<string> strings, Queue<Diagnostic> diagnostics);

    internal abstract IEnumerable<Record424> GetSequence(Record424 record);
}

internal sealed class SequenceAttribute<TRecord, TSub>() : SequenceAttribute(typeof(TRecord), typeof(TSub))
    where TRecord : Record424<TSub>, new()
    where TSub : Record424, new()
{
    private readonly BuildInfo<TRecord> info = new(typeof(TRecord), typeof(TRecord).GetProperties());

    private readonly BuildInfo<TSub> subInfo = new(typeof(TSub), typeof(TSub).GetProperties());

    internal override Record424 Build(Queue<string> strings, Queue<Diagnostic> diagnostics)
        => RecordBuilder<TRecord, TSub>.Build(strings, info, subInfo, diagnostics);

    internal override IEnumerable<Record424> GetSequence(Record424 record) => ((TRecord)record).Sequence;
}
