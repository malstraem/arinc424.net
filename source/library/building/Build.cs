using Arinc424.Diagnostics;

namespace Arinc424.Building;

[DebuggerDisplay($"{{{nameof(Record)}}}")]
internal abstract class Build(Record424 record)
{
    internal Record424 Record { get; } = record;

    internal Queue<Diagnostic>? Diagnostics { get; set; }
}

internal class Build<TRecord>(TRecord record) : Build(record) where TRecord : Record424
{
    internal new TRecord Record { get; } = record;
}

internal class Build<TSequence, TSub>(TSequence sequence) : Build<TSequence>(sequence) where TSequence : Record424<TSub> where TSub : Record424
{
    internal new TSequence Record { get; } = sequence;
}
