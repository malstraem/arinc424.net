using Arinc424.Building;
using Arinc424.Comms;
using Arinc424.Diagnostics;

namespace Arinc424.Processing;

internal abstract class CommTriggerBeforeV19<TRecord> : ITrigger<TRecord> where TRecord : Record424
{
    private static readonly Range range = 6..10;

    public static bool Check(TRecord one, TRecord another) => one.Source![range] != another.Source![range];
}

internal sealed class CommWrapBeforeV19<TComm, TTransmitter>(Supplement supplement) : Scan<TComm, TTransmitter, CommTriggerBeforeV19<TTransmitter>>
    where TComm : Communication<TTransmitter>, new()
    where TTransmitter : Transmitter
{
    private readonly BuildInfo<TComm> info = new(supplement);

    protected override Build<TComm> Build(Queue<Build<TTransmitter>> sources, ref Queue<Diagnostic> diagnostics)
    {
        var comm = sources.First();

        Build<TComm> build = new(RecordBuilder<TComm>.Build(comm.Record.Source!, info, diagnostics));

        build.Record.Sequence = [];

        while (sources.TryDequeue(out var source))
        {
            build.Record.Sequence.Add(source.Record);

            if (diagnostics.Count != 0)
            {
                comm.Diagnostics ??= [];
                comm.Diagnostics.Pump(diagnostics);
            }
        }
        return build;
    }
}
