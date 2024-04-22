using System.Reflection;

using Arinc424.Building;

namespace Arinc424.Attributes;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
internal abstract class SequenceAttribute : InfoAttribute
{
    internal readonly Range Range;

    internal readonly RelationsAttribute SubInfo;

    internal SequenceAttribute(Type type, Type subType) : base(type, type.GetProperties())
    {
        Range = type.GetCustomAttribute<SequencedAttribute>()!.Range;

        SubInfo = new RelationsAttribute(subType, subType.GetProperties());
    }

    internal abstract Record424 Build(Queue<string> strings);

    internal abstract IEnumerable<Record424> GetSequence(Record424 record);
}

internal class SequenceAttribute<TRecord, TSub> : SequenceAttribute where TRecord : Record424<TSub>, new()
                                                                    where TSub : Record424, new()
{
    internal SequenceAttribute() : base(typeof(TRecord), typeof(TSub)) { }

    internal override Record424 Build(Queue<string> strings) => RecordBuilder<TRecord, TSub>.Build(strings);

    internal override IEnumerable<Record424> GetSequence(Record424 record) => ((TRecord)record).Sequence;
}
