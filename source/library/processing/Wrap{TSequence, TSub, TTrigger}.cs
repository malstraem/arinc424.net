using Arinc424.Building;
using Arinc424.Diagnostics;

namespace Arinc424.Processing;

internal abstract class Wrap<TSequence, TSub, TTrigger>(Supplement supplement) : Scan<TSequence, TSub, TTrigger>
    where TSequence : Record424<TSub>, new()
    where TSub : Record424
    where TTrigger : ITrigger<TSub>
{
    private readonly BuildInfo<TSequence> info = new(supplement);

    protected override Build<TSequence> Build(Queue<Build<TSub>> subs, ref Queue<Diagnostic> diagnostics)
    {
        Build<TSequence, TSub> build = new(RecordBuilder<TSequence>.Build(subs.First().Record.Source!, new TSequence(), info, diagnostics));

        build.Record.Sequence = [];

        while (subs.TryDequeue(out var sub))
        {
            build.Record.Sequence.Add(sub.Record);

            if (sub.Diagnostics is not null)
                diagnostics.Pump(sub.Diagnostics);
        }

        if (diagnostics.Count != 0)
        {
            build.Diagnostics = diagnostics;
            diagnostics = [];
        }
        return build;
    }
}

internal sealed class IdentityWrap<TSequence, TSub>(Supplement supplement) : Wrap<TSequence, TSub, IdentifierTrigger<TSub>>(supplement)
    where TSequence : Record424<TSub>, new()
    where TSub : Record424, IIdentity;

internal sealed class MultipleWrap<TSequence, TSub>(Supplement supplement) : Wrap<TSequence, TSub, MultipleTrigger<TSub>>(supplement)
    where TSequence : Record424<TSub>, new()
    where TSub : Record424, IMultiple;
