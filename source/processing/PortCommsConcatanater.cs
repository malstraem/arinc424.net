using Arinc424.Building;
using Arinc424.Comms;
using Arinc424.Diagnostics;

namespace Arinc424.Processing;

internal abstract class PortCommsConcatanater : IProcessor<PortCommunication, PortCommunication>
{
    public static IEnumerable<Build<PortCommunication>> Process(Queue<Build<PortCommunication>> builds)
    {
        Queue<Build<PortCommunication>> result = new(builds.Count);

        var enumerator = builds.GetEnumerator();

        if (!enumerator.MoveNext())
            return result;

        Build<PortCommunication> next, current;

        var range = 6..10; // port identifier range

        var info = new BuildInfo<PortTransmitter>(Supplement.V18);

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

        PortTransmitter GetTransmitter(Build<PortCommunication> build)
        {
            var transmitter = RecordBuilder<PortTransmitter>.Build(build.Record.Source!, info, diagnostics);

            if (diagnostics.Count != 0)
            {
                current.Diagnostics ??= [];
                current.Diagnostics.Enqueue(diagnostics);
            }
            return transmitter;
        };
    }
}
