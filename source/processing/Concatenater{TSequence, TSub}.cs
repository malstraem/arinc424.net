using Arinc424.Building;

namespace Arinc424.Processing;

internal abstract class Concatenater<TSequence, TSub> where TSequence : Record424<TSub>, new() where TSub : Record424, new()
{
    [Obsolete("todo: save diagnostics")]
    internal static Queue<Build<TSequence>> Concat(Queue<Build<TSub>> builds, Func<TSub, TSequence> @new, Func<TSub, TSub, bool> trigger)
    {
        var enumerator = builds.GetEnumerator();

        Queue<TSub> subs = [];
        Queue<Build<TSequence>> sequences = [];

        TSub sub, next;

        if (enumerator.MoveNext())
        {
            subs.Enqueue(sub = enumerator.Current.Record);

            while (enumerator.MoveNext())
            {
                next = enumerator.Current.Record;

                if (trigger(sub, next))
                {
                    Enqueue();
                    subs.Clear();
                }
                subs.Enqueue(sub = next);
            }
            Enqueue();

            void Enqueue()
            {
                var result = @new(sub);

                result.Source = sub.Source;
                result.Code = sub.Code;
                result.Sequence = [.. subs];

                sequences.Enqueue(new Build<TSequence, TSub>(result)); // todo: save diagnostics
                subs.Clear();
            }
        }
        return sequences;
    }
}
