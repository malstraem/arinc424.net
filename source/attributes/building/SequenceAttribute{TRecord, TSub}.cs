using System.Reflection;

using Arinc424.Building;
using Arinc424.Diagnostics;

namespace Arinc424.Attributes;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
internal abstract class SequenceAttribute : InfoAttribute
{
    internal readonly Range Range;

    internal readonly BuildAttribute SubInfo;

    internal SequenceAttribute(Type type, Type subType) : base(type, type.GetProperties())
    {
        Range = type.GetCustomAttribute<SequencedAttribute>()!.Range;

        SubInfo = new BuildAttribute(subType, subType.GetProperties());
    }

    internal abstract Record424 Build(Queue<string> strings, Queue<Diagnostic> diagnostics);

    internal abstract IEnumerable<Record424> GetSequence(Record424 record);
}

internal sealed class SequenceAttribute<TRecord, TSub>() : SequenceAttribute(typeof(TRecord), typeof(TSub))
    where TRecord : Record424<TSub>, new()
    where TSub : Record424, new()
{
    internal override Record424 Build(Queue<string> strings, Queue<Diagnostic> diagnostics) => RecordBuilder<TRecord, TSub>.Build(strings, this, diagnostics);

    internal override IEnumerable<Record424> GetSequence(Record424 record) => ((TRecord)record).Sequence;
}
