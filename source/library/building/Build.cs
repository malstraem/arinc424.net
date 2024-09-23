using Arinc424.Diagnostics;

namespace Arinc424.Building;

[DebuggerDisplay($"{{{nameof(Record)}}}")]
public abstract class Build(Record424 record)
{
    public Record424 Record { get; } = record;

    public Queue<Diagnostic>? Diagnostics { get; set; }
}

public class Build<TRecord>(TRecord record) : Build(record)
    where TRecord : Record424
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public new TRecord Record { get; } = record;
}

public class Build<TSequence, TSub>(TSequence sequence) : Build<TSequence>(sequence)
    where TSequence : Record424<TSub> where TSub : Record424
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public new TSequence Record { get; } = sequence;
}
