using Arinc424.Building;
using Arinc424.Comms;
using Arinc424.Diagnostics;

namespace Arinc424.Processing;

[Obsolete("try to generalize 'scanner' logic")]
internal class CommWrapBeforeV19<TComm, TTransmitter>(Supplement supplement) : IPipeline<TComm, TComm>
    where TComm : Communication<TTransmitter>
    where TTransmitter : Transmitter, new()
{
    private readonly BuildInfo<TTransmitter> info = new(supplement);

    public IEnumerable<Build<TComm>> Process(Queue<Build<TComm>> builds)
    {
        Queue<Build<TComm>> result = new(builds.Count);

        var enumerator = builds.GetEnumerator();

        if (!enumerator.MoveNext())
            return result;

        Build<TComm> next, current;

        var range = 6..10; // port identifier range

        var diagnostics = new Queue<Diagnostic>();

        result.Enqueue(current = enumerator.Current);

        var transmitters = current.Record.Sequence = [GetTransmitter(current)];

        while (enumerator.MoveNext())
        {
            next = enumerator.Current;

            if (current.Record.Source![range] != next.Record.Source![range])
            {
                result.Enqueue(current = next);
                transmitters = current.Record.Sequence = [GetTransmitter(current)];
                continue;
            }
            current = next;
            transmitters.Add(GetTransmitter(current));
        }
        return result;

        TTransmitter GetTransmitter(Build<TComm> build)
        {
            var transmitter = RecordBuilder<TTransmitter>.Build(build.Record.Source!, info, diagnostics);

            if (diagnostics.Count != 0)
            {
                current.Diagnostics ??= [];
                current.Diagnostics.Pump(diagnostics);
            }
            return transmitter;
        };
    }
}
