using Arinc424.Building;
using Arinc424.Comms;
using Arinc424.Diagnostics;

namespace Arinc424.Processing;

internal abstract class PortCommsConcatanater : IProcessor<AirportCommunication, AirportCommunication>
{
    public static IEnumerable<Build<AirportCommunication>> Process(Queue<Build<AirportCommunication>> builds)
    {
        Queue<Build<AirportCommunication>> result = new(builds.Count);

        var enumerator = builds.GetEnumerator();

        if (!enumerator.MoveNext())
            return result;

        Build<AirportCommunication> next, current;

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

        PortTransmitter GetTransmitter(Build<AirportCommunication> build)
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
