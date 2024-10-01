using Arinc424.Building;
using Arinc424.Diagnostics;

namespace Arinc424.Processing;

internal abstract class Scan<TNew, TSource, TTrigger> : IPipeline<TNew, TSource>
    where TNew : Record424
    where TSource : Record424
    where TTrigger : ITrigger<TSource>
{
    protected abstract Build<TNew> Build(Queue<Build<TSource>> sources, ref Queue<Diagnostic> diagnostics);

    public IEnumerable<Build<TNew>> Process(Queue<Build<TSource>> builds)
    {
        Build<TSource> next, current;

        Queue<Build<TNew>> @new = new(builds.Count);

        var enumerator = builds.GetEnumerator();

        if (!enumerator.MoveNext())
            return @new;

        Queue<Build<TSource>> sources = [];
        Queue<Diagnostic> diagnostics = [];

        sources.Enqueue(current = enumerator.Current);

        while (enumerator.MoveNext())
        {
            next = enumerator.Current;

            if (TTrigger.Check(current.Record, next.Record))
                @new.Enqueue(Build(sources, ref diagnostics));

            sources.Enqueue(current = next);
        }
        @new.Enqueue(Build(sources, ref diagnostics));

        return @new;
    }
}
