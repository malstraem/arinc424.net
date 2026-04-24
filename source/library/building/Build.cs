namespace Arinc424;

/**<summary>
Proxy to hold bad coded record with diagnostics.
</summary>*/
[DebuggerDisplay($"{{{nameof(Record)}}}")]
internal abstract class Build(Record424 record)
{
    internal Record424 Record { get; } = record;

    internal Queue<Diagnostic>? Diagnostics { get; set; }
}

/// <exclude />
internal class Build<R>(R record)
    : Build(record)
        where R : Record424
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    internal new R Record { get; } = record;
}

internal interface ISequentBuild
{
    Build[] Builds { get; }
}

/// <exclude />
internal class Build<R, S>(R sequence, Build[] builds)
    : Build<R>(sequence), ISequentBuild
        where R : Record424<S>
        where S : Record424
{
    Build[] ISequentBuild.Builds => builds;
}
