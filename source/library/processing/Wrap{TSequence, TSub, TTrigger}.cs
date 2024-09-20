using Arinc424.Building;
using Arinc424.Diagnostics;

namespace Arinc424.Processing;

internal class Wrap<TSequence, TSub, TTrigger>(Supplement supplement) : IPipeline<TSequence, TSub>
    where TSequence : Record424<TSub>, new()
    where TSub : Record424
    where TTrigger : ITrigger<TSub>
{
    private readonly BuildInfo<TSequence> info = new(supplement);

    public IEnumerable<Build<TSequence>> Process(Queue<Build<TSub>> builds)
    {
        Build<TSub> current, next;

        var enumerator = builds.GetEnumerator();

        Queue<Build<TSequence>> sequences = [];

        if (!enumerator.MoveNext())
            return sequences;

        Queue<Build<TSub>> subs = [];

        Queue<Diagnostic> diagnostics = [];

        subs.Enqueue(current = enumerator.Current);

        while (enumerator.MoveNext())
        {
            next = enumerator.Current;

            if (TTrigger.Check(current.Record, next.Record))
                sequences.Enqueue(Wrap());

            subs.Enqueue(current = next);
        }
        sequences.Enqueue(Wrap());

        return sequences;

        Build<TSequence> Wrap()
        {
            var build = new Build<TSequence, TSub>(RecordBuilder<TSequence>.Build(current.Record.Source!, new TSequence(), info, diagnostics));

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
}
