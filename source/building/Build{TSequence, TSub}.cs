namespace Arinc424.Building;

internal class Build<TSequence, TSub>(TSequence sequence) : Build<TSequence>(sequence) where TSequence : Record424<TSub> where TSub : Record424
{
    internal new TSequence Record { get; } = sequence;
}
