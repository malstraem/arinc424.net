using Arinc424.Comms;
using Arinc424.Ground;
using Arinc424.Linking;
using Arinc424.Processing;

namespace Arinc424.Attributes;

internal abstract class PipelineAttribute<TSource>(Type newType, Supplement start, Supplement end) : SupplementAttribute(start, end)
    where TSource : Record424
{
    internal abstract IPipeline<TSource> GetPipeline(Supplement supplement);

    internal abstract Relations GetRelations(Supplement supplement);

    internal Type NewType { get; } = newType;
}

[AttributeUsage(AttributeTargets.Class)]
internal class WrapAttribute<TSequence, TSub, TTrigger>(Supplement start = Supplement.V18, Supplement end = Supplement.V23)
    : PipelineAttribute<TSub>(typeof(TSequence), start, end)
        where TSequence : Record424<TSub>, new()
        where TSub : Record424
        where TTrigger : ITrigger<TSub>
{
    internal override IPipeline<TSub> GetPipeline(Supplement supplement)
    {
        return new Wrap<TSequence, TSub, TTrigger>(supplement);
    }

    internal override Relations<TSequence> GetRelations(Supplement supplement) => new(supplement);
}

[AttributeUsage(AttributeTargets.Class)]
internal class CommWrapBeforeV19Attribute<TComm, TTransmitter>(Supplement end = Supplement.V19)
    : PipelineAttribute<TComm>(typeof(TComm), Supplement.V18, end)
        where TComm : Communication<TTransmitter>
        where TTransmitter : Transmitter, new()
{
    internal override IPipeline<TComm> GetPipeline(Supplement supplement)
    {
        return new CommWrapBeforeV19<TComm, TTransmitter>(supplement);
    }

    internal override Relations<TComm> GetRelations(Supplement supplement) => new(supplement);
}

[AttributeUsage(AttributeTargets.Class)]
internal class HelipadWrapBeforeV21Attribute(Supplement start = Supplement.V18, Supplement end = Supplement.V21)
    : PipelineAttribute<Heliport>(typeof(Heliport), start, end)
{
    internal override IPipeline<Heliport> GetPipeline(Supplement supplement)
    {
        return new HelipadWrapBeforeV21();
    }

    internal override Relations<Heliport> GetRelations(Supplement supplement) => new(supplement);
}
