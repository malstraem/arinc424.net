using System.Reflection;

namespace Arinc424.Processing;

using Building;
using Airspace;

internal abstract class Wrap<R, S>(Supplement supplement)
    : Scan<R, S>
        where R : Record424<S>, new()
        where S : Record424
{
    private readonly BuildInfo<R> info = new(supplement);

    protected override Build<R> Build(Queue<Build<S>> subs, ref Queue<Diagnostic> diagnostics)
        => RecordBuilder<R, S>.Build(subs, info, ref diagnostics);
}

internal sealed class Sequence<R, S>(Supplement supplement)
    : Wrap<R, S>(supplement)
        where R : Record424<S>, new()
        where S : Record424, ISequenced
{
    protected override bool Trigger(S current, S next)
        => next.SeqNumber <= current.SeqNumber;
}

internal sealed class IdentityWrap<R, S>(Supplement supplement)
    : Wrap<R, S>(supplement)
        where R : Record424<S>, IIdentity, new()
        where S : Record424
{
    private readonly Range range = typeof(R).GetCustomAttributes<IdAttribute>()
                                            .BySupplement(supplement)!.Range;
    protected override bool Trigger(S current, S next)
        => current.Source![range] != next.Source![range];
}

internal sealed class RestrictedWrap(Supplement supplement)
    : Wrap<RestrictedSpace, Restricted>(supplement)
{
    /**<summary>
    Range including <see cref="IIcao.Icao"/>, <see cref="Restricted.Type"/>
    and <see cref="RestrictedSpace.Identifier"/>.
    </summary>*/
    private readonly Range range = 6..19;

    protected override bool Trigger(Restricted current, Restricted next)
        => current.Source![range] != next.Source![range];
}
