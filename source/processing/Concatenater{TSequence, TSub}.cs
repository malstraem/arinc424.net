using Arinc424.Building;

namespace Arinc424.Processing;

internal abstract class Concatenater<TSequence, TSub> where TSequence : Record424<TSub>, new() where TSub : Record424, new()
{
    internal static Queue<Build<TSequence>> Concat(Queue<Build<TSub>> builds, Func<TSub, TSequence> @new, Func<TSub, TSub, bool> trigger)
    {
        var enumerator = builds.GetEnumerator();

        Queue<TSub> sequence = [];
        Queue<Build<TSequence>> procedures = [];

        TSub sub, next;

        if (enumerator.MoveNext())
        {
            sequence.Enqueue(sub = enumerator.Current.Record);

            while (enumerator.MoveNext())
            {
                next = enumerator.Current.Record;

                if (trigger(next, sub))
                {
                    Enqueue();
                    sequence.Clear();
                }
                sequence.Enqueue(sub = next);
            }
            Enqueue();

            void Enqueue()
            {
                var result = @new(sub);
                result.Sequence = [.. sequence];

                procedures.Enqueue(new Build<TSequence, TSub>(result)); // todo: save diagnostics
                sequence.Clear();
            }
        }
        return procedures;
    }
}
