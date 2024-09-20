using Arinc424.Comms;
using Arinc424.Ground;
using Arinc424.Processing;

namespace Arinc424.Attributes;

internal abstract class PipelineAttribute<TSource>(Type outType, Supplement start, Supplement end) : SupplementAttribute(start, end)
    where TSource : Record424
{
    internal abstract IPipeline<TSource> GetPipeline(Supplement supplement);

    internal Type OutType { get; } = outType;
}

[AttributeUsage(AttributeTargets.Class)]
internal class WrapAttribute<TSequence, TSub, TTrigger>(Supplement start = Supplement.V18, Supplement end = Supplement.V23)
    : PipelineAttribute<TSub>(typeof(TSequence), start, end)
        where TSequence : Record424<TSub>, new()
        where TSub : Record424
        where TTrigger : ITrigger<TSub>
{
    internal override IPipeline<TSub> GetPipeline(Supplement supplement) => new Wrap<TSequence, TSub, TTrigger>(supplement);
}

[AttributeUsage(AttributeTargets.Class)]
internal class CommWrapBeforeV19Attribute<TComm, TTransmitter>(Supplement end = Supplement.V19)
    : PipelineAttribute<TComm>(typeof(TComm), Supplement.V18, end)
        where TComm : Communication<TTransmitter>
        where TTransmitter : Transmitter, new()
{
    internal override IPipeline<TComm> GetPipeline(Supplement supplement) => new CommWrapBeforeV19<TComm, TTransmitter>(supplement);
}

[AttributeUsage(AttributeTargets.Class)]
internal class HelipadWrapBeforeV21Attribute(Supplement start = Supplement.V18, Supplement end = Supplement.V21)
    : PipelineAttribute<Heliport>(typeof(Heliport), start, end)
{
    internal override IPipeline<Heliport> GetPipeline(Supplement supplement) => new HelipadWrapBeforeV21();
}
