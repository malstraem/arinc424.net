using Arinc424.Building;
using Arinc424.Comms;
using Arinc424.Diagnostics;

namespace Arinc424.Processing;

internal abstract class CommTriggerBeforeV19<TRecord> : ITrigger<TRecord> where TRecord : Record424
{
    private static readonly Range range = 6..10;

    public static bool Check(TRecord one, TRecord another) => one.Source![range] != another.Source![range];
}

internal sealed class CommWrapBeforeV19<TComm, TTransmitter>(Supplement supplement) : Scan<TComm, TComm, CommTriggerBeforeV19<TComm>>
    where TComm : Communication<TTransmitter>
    where TTransmitter : Transmitter, new()
{
    private readonly BuildInfo<TTransmitter> info = new(supplement);

    protected override Build<TComm> Build(Queue<Build<TComm>> sources, ref Queue<Diagnostic> diagnostics)
    {
        var comm = sources.First();

        comm.Record.Sequence = [];

        while (sources.TryDequeue(out var source))
        {
            comm.Record.Sequence.Add(RecordBuilder<TTransmitter>.Build(source.Record.Source!, info, diagnostics));

            if (diagnostics.Count != 0)
            {
                comm.Diagnostics ??= [];
                comm.Diagnostics.Pump(diagnostics);
            }
        }
        return comm;
    }
}
