using Arinc424.Diagnostics;

namespace Arinc424.Building;

/// <summary>
/// Proxy to hold bad coded record with diagnostics.
/// </summary>
[DebuggerDisplay($"{{{nameof(Record)}}}")]
public abstract class Build
{
    internal Build(Record424 record) => Record = record;

    public Record424 Record { get; }

    public Queue<Diagnostic>? Diagnostics { get; set; }
}

/// <exclude />
public class Build<TRecord>(TRecord record) : Build(record) where TRecord : Record424
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public new TRecord Record { get; } = record;
}

/// <exclude />
public class Build<TSequence, TSub>(TSequence sequence) : Build<TSequence>(sequence)
    where TSequence : Record424<TSub>
    where TSub : Record424
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public new TSequence Record { get; } = sequence;
}
