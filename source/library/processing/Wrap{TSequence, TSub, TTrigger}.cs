using System.Reflection;

namespace Arinc424.Processing;

using Building;
using Airspace;
using Diagnostics;

internal abstract class Wrap<TSequence, TSub>(Supplement supplement) : Scan<TSequence, TSub>
    where TSequence : Record424<TSub>, new()
    where TSub : Record424
{
    private readonly BuildInfo<TSequence> info = new(supplement);

    protected override Build<TSequence> Build(Queue<Build<TSub>> subs, ref Queue<Diagnostic> diagnostics)
        => RecordBuilder<TSequence, TSub>.Build(subs, info, ref diagnostics);
}

internal sealed class Sequence<TSequence, TSub>(Supplement supplement) : Wrap<TSequence, TSub>(supplement)
    where TSequence : Record424<TSub>, new()
    where TSub : Record424, ISequenced
{
    protected override bool Trigger(TSub current, TSub next) => next.SeqNumber <= current.SeqNumber;
}

internal sealed class IdentityWrap<TSequence, TSub>(Supplement supplement) : Wrap<TSequence, TSub>(supplement)
    where TSequence : Record424<TSub>, IIdentity, new()
    where TSub : Record424
{
    private readonly Range range = typeof(TSequence).GetCustomAttribute<IdentifierAttribute>()!.Range;

    protected override bool Trigger(TSub current, TSub next) => current.Source![range] != next.Source![range];
}

internal sealed class RestrictiveWrap(Supplement supplement) : Wrap<RestrictiveSpace, RestrictiveVolume>(supplement)
{
    /**<summary>
    Range including <see cref="IIcao.Icao"/>, <see cref="RestrictiveVolume.Type"/>
    and <see cref="RestrictiveSpace.Identifier"/>.
    </summary>*/
    private readonly Range range = 6..19;

    protected override bool Trigger(RestrictiveVolume current, RestrictiveVolume next) => current.Source![range] != next.Source![range];
}
