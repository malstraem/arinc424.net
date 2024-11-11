using System.Reflection;

using Arinc424.Building;
using Arinc424.Diagnostics;

namespace Arinc424.Processing;

internal sealed class Sequence<TSequence, TSub>(Supplement supplement) : IPipeline<TSequence, TSub>
    where TSequence : Record424<TSub>, new()
    where TSub : Record424
{
    private readonly Range range = typeof(TSequence).GetCustomAttribute<SequencedAttribute>()!.Range;

    private readonly BuildInfo<TSequence> info = new(supplement);

    private Build<TSequence> Build(Queue<Build<TSub>> subs, ref Queue<Diagnostic> diagnostics)
    {
        var sub = subs.First();

        Build<TSequence, TSub> build = new(RecordBuilder<TSequence>.Build(sub.Record.Source!, new TSequence(), info, diagnostics));

        build.Record.Sequence = [];

        while (subs.TryDequeue(out sub))
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

    [Obsolete("todo")]
    public Queue<Build<TSequence>> Process(Queue<Build<TSub>> builds)
    {
        Build<TSub> next, current;

        Queue<Build<TSequence>> @new = new(builds.Count);

        var enumerator = builds.GetEnumerator();

        if (!enumerator.MoveNext())
            return @new;

        Queue<Build<TSub>> sources = [];
        Queue<Diagnostic> diagnostics = [];

        sources.Enqueue(current = enumerator.Current);

        if (!int.TryParse(current.Record.Source![range], out int sequenceNumber))
        {
            Console.WriteLine("oops");
        }

        while (enumerator.MoveNext())
        {
            next = enumerator.Current;

            if (!int.TryParse(next.Record.Source![range], out int nextSequenceNumber))
            {
                Console.WriteLine("oops");
            }

            if (nextSequenceNumber <= sequenceNumber)
                @new.Enqueue(Build(sources, ref diagnostics));

            sources.Enqueue(next);

            sequenceNumber = nextSequenceNumber;
        }
        @new.Enqueue(Build(sources, ref diagnostics));

        return @new;
    }
}
