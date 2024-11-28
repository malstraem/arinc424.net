using Arinc424.Building;
using Arinc424.Diagnostics;

namespace Arinc424.Processing;

internal abstract class Scan<TOut, TSource> : IPipeline<TOut, TSource> where TOut : Record424 where TSource : Record424
{
    protected abstract bool Trigger(TSource current, TSource next);

    /// <summary>
    /// Creates an instance of <typeparamref name="TOut"/> saving diagnostics.
    /// </summary>
    /// <remarks>All overrides should dequeue <paramref name="sources"/>.</remarks>
    protected abstract Build<TOut> Build(Queue<Build<TSource>> sources, ref Queue<Diagnostic> diagnostics);

    public Queue<Build<TOut>> Process(Queue<Build<TSource>> builds)
    {
        Build<TSource> next, current;

        Queue<Build<TOut>> @new = new();

        var enumerator = builds.GetEnumerator();

        if (!enumerator.MoveNext())
            return @new;

        Queue<Diagnostic> diagnostics = [];
        Queue<Build<TSource>> sources = [];

        sources.Enqueue(current = enumerator.Current);

        while (enumerator.MoveNext())
        {
            next = enumerator.Current;

            if (Trigger(current.Record, next.Record))
                @new.Enqueue(Build(sources, ref diagnostics));

            sources.Enqueue(current = next);
        }
        @new.Enqueue(Build(sources, ref diagnostics));

        return @new;
    }
}
