namespace Arinc424.Processing;

internal sealed class Sequence<TSequence, TSub>(Supplement supplement) : Wrap<TSequence, TSub>(supplement)
    where TSequence : Record424<TSub>, new()
    where TSub : Record424, ISequenced
{
    protected override bool Trigger(TSub current, TSub next) => next.SeqNumber <= current.SeqNumber;
}
