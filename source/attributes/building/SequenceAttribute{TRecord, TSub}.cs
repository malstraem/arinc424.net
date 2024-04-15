using System.Reflection;

using Arinc424.Building;

namespace Arinc424.Attributes;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
internal abstract class SequenceAttribute : InfoAttribute
{
    internal readonly Range Range;

    internal SequenceAttribute(Type type, Type subType) : base(type)
    {
        Range = type.GetCustomAttribute<SequencedAttribute>()!.Range;

        //LinkingInfo.TryCreate(subType, out SubLinkingInfo);
    }

    internal abstract Record424 Build(Queue<string> strings);
}

internal class SequenceAttribute<TRecord, TSub> : SequenceAttribute where TRecord : Record424<TSub>, new()
                                                                    where TSub : Record424, new()
{
    internal SequenceAttribute() : base(typeof(TRecord), typeof(TSub)) { }

    internal override Record424 Build(Queue<string> strings) => RecordBuilder<TRecord, TSub>.Build(strings);
}
