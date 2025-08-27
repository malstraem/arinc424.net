namespace Arinc424;

/**<summary>
Proxy to hold bad coded record with diagnostics.
</summary>*/
[DebuggerDisplay($"{{{nameof(Record)}}}")]
internal abstract class Build(Record424 record)
{
    public Record424 Record { get; } = record;

    public Queue<Diagnostic>? Diagnostics { get; set; }
}

/// <exclude />
internal class Build<TRecord>(TRecord record) : Build(record) where TRecord : Record424
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    internal new TRecord Record { get; } = record;
}

internal interface ISequentBuild
{
    Build[] Builds { get; }
}

/// <exclude />
internal class Build<TSequence, TSub>(TSequence sequence, Build<TSub>[] builds) : Build<TSequence>(sequence), ISequentBuild
    where TSequence : Record424<TSub>
    where TSub : Record424
{
    public Build<TSub>[] Builds { get; } = builds;

    Build[] ISequentBuild.Builds => Builds;
}
