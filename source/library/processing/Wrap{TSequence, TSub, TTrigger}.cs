using System.Reflection;

using Arinc424.Building;
using Arinc424.Diagnostics;

namespace Arinc424.Processing;

internal abstract class Wrap<TSequence, TSub>(Supplement supplement) : Scan<TSequence, TSub>
    where TSequence : Record424<TSub>, new()
    where TSub : Record424
{
    private readonly BuildInfo<TSequence> info = new(supplement);

    protected override Build<TSequence> Build(Queue<Build<TSub>> subs, ref Queue<Diagnostic> diagnostics)
        => RecordBuilder<TSequence, TSub>.Build(subs, info, ref diagnostics);
}

internal sealed class IdentityWrap<TSequence, TSub>(Supplement supplement) : Wrap<TSequence, TSub>(supplement)
    where TSequence : Record424<TSub>, IIdentity, new()
    where TSub : Record424
{
    private readonly Range range = typeof(TSequence).GetCustomAttribute<IdentifierAttribute>()!.Range;

    protected override bool Trigger(TSub current, TSub next) => current.Source![range] != next.Source![range];
}

[Obsolete("most likely it needs to be done differently")]
internal sealed class MultipleWrap<TSequence, TSub>(Supplement supplement) : Wrap<TSequence, TSub>(supplement)
    where TSequence : Record424<TSub>, new()
    where TSub : Record424, IMultiple
{
    protected override bool Trigger(TSub current, TSub next) => char.IsWhiteSpace(current.Multiplier)
                                                             || char.IsWhiteSpace(next.Multiplier)
                                                             || next.Multiplier <= current.Multiplier;
}
